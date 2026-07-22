using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using PokedexG.Web;
using PokedexG.Web.Services;

// Même culture que l'app d'origine (DefaultLanguage fr-FR du manifeste UWP).
var culture = new CultureInfo("fr-FR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new SettingsService((IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>()));
builder.Services.AddScoped<VeekunClient>();

await builder.Build().RunAsync();
