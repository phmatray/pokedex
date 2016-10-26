using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PokemonAPI.WebService.Controllers;
using Swashbuckle.Swagger.Model;

namespace PokemonAPI.WebService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            // JSON options issue solved
            // http://stackoverflow.com/questions/39024354/asp-net-core-api-only-returning-first-result-of-list

            services
                .AddMvc(o =>
                {
                    o.ReturnHttpNotAcceptable = true;
                    o.RespectBrowserAcceptHeader = true;
                })
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.Formatting = Formatting.Indented;

                    // Use Snake Case Naming
                    var resolver = o.SerializerSettings.ContractResolver;
                    var res = resolver as DefaultContractResolver;
                    if (res != null)
                        res.NamingStrategy = new SnakeCaseNamingStrategy(); // <<!-- this change the camelcasing
                });

            var connection = @"Server=(localdb)\MSSQLLocalDB;Database=veekun;Trusted_Connection=True;";
            services.AddDbContext<VeekunContext>(options => options
                .UseSqlServer(connection)
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning)));

            // Add Memory Caching
            services.AddMemoryCache();



            services.AddTransient<IPokemonsService, PokemonsService>();
            services.AddTransient<IPokemonsCacheService, PokemonsCacheService>();




            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen();

            // Add the detail information for the API.
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "PokedexG API",
                    Description = "All the Pokémon data you'll ever need, in one place, and easily accessible through a modern RESTful API.",
                    Contact = new Contact { Name = "Philippe Matray", Email = "phmatray@outlook.com", Url = "http://phmatray.net" }
                });

                //Determine base path for the application.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //Set the comments path for the swagger json and ui.
                options.IncludeXmlComments(basePath + "\\PokemonAPI.WebService.xml");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            // Enable middleware to caching
            //app.UsePokemonsMiddleware();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
        }
    }
}
