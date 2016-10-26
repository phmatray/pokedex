////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Net.Http;
////using System.Threading.Tasks;
////using Newtonsoft.Json;
////using PokemonAPI.Models.Rsc;
////using Type = PokemonAPI.Models.Rsc.Type;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI
{
    public static class TaskExtensions
    {
        public static async Task<List<T>> ToListWhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            return (await Task.WhenAll(tasks)).ToList();
        }
    }

    //public static class DataFetcherExtensions
    //{
    //    public static async Task<List<T>> GetDetails<T>(this List<NamedAPIResource> namedApiResourceList)
    //    {
    //        return await namedApiResourceList
    //            .Select(x => GetResource<T>(x.Url))
    //            .ToListWhenAll();
    //    }
    //}




    public static class DataFetcher
    {
        private static IDataFetcherConfig _config;
        private static HttpClient _client;

        public static IDataFetcherConfig Config
        {
            get { return _config; }
            set
            {
                _config = value;
                _client = new HttpClient
                {
                    BaseAddress = new Uri($"{_config.SiteUrl}{_config.BaseUrl}")
                };
            }
        }

        public static async Task<NamedAPIResourceList> GetGenerations()
        {
            return await GetResource<NamedAPIResourceList>("generations");
        }

        public static async Task<List<Generation>> GetGenerationDetails()
        {
            return await GetDetails<Generation>(await GetGenerations());
        }

        public static async Task<Generation> GetGeneration(int id)
        {
            return await GetResource<Generation>($"generations/{id}");
        }

        public static async Task<NamedAPIResourceList> GetPokemons()
        {
            return await GetResource<NamedAPIResourceList>("pokemons?limit=1000&offset=0");
        }

        public static async Task<Pokemon> GetPokemon(int id)
        {
            return await GetResource<Pokemon>($"pokemons/{id}");
        }






        public static async Task<T> GetResource<T>(string requestUri)
        {
            var response = await _client.GetAsync(requestUri);
            var json = await response.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<T>(json);

            return deserializedObject;
        }

        public static async Task<List<T>> GetDetails<T>(this NamedAPIResourceList namedApiResourceList)
        {
            return await GetDetails<T>(namedApiResourceList.Results);
        }

        public static async Task<List<T>> GetDetails<T>(this APIResourceList apiResourceList)
        {
            return await GetDetails<T>(apiResourceList.Results);
        }

        public static async Task<List<T>> GetDetails<T>(this List<NamedAPIResource> namedApiResourceList)
        {
            return await namedApiResourceList
                .AsParallel()
                .Select(x => GetResource<T>(x.Url))
                .ToListWhenAll();
        }

        public static async Task<List<T>> GetDetails<T>(this List<APIResource> apiResourceList)
        {
            return await apiResourceList
                .AsParallel()
                .Select(x => GetResource<T>(x.Url))
                .ToListWhenAll();
        }
    }




    //public class DataFetcher
    //{
    //    public HttpClient Client { get; }

    //    public DataFetcher(IDataFetcherConfig config)
    //    {
    //        Client = new HttpClient { BaseAddress = new Uri($"{config.SiteUrl}{config.BaseUrl}") };
    //    }


    //    public async Task<NamedAPIResourceList> GetGenerations()
    //    {
    //        return await GetResource<NamedAPIResourceList>("generations");
    //    }

    //    public async Task<List<Generation>> GetGenerationDetails()
    //    {
    //        return await GetDetails<Generation>(await GetGenerations());
    //    }


    //    public async Task<T> GetResource<T>(string requestUri)
    //    {
    //        var response = await Client.GetAsync(requestUri);
    //        var json = await response.Content.ReadAsStringAsync();
    //        var deserializedObject = JsonConvert.DeserializeObject<T>(json);

    //        return deserializedObject;
    //    }

    //    public async Task<List<T>> GetDetails<T>(NamedAPIResourceList namedApiResourceList)
    //    {
    //        return await GetDetails<T>(namedApiResourceList.Results);
    //    }

    //    public async Task<List<T>> GetDetails<T>(APIResourceList apiResourceList)
    //    {
    //        return await GetDetails<T>(apiResourceList.Results);
    //    }

    //    public async Task<List<T>> GetDetails<T>(List<NamedAPIResource> namedApiResourceList)
    //    {
    //        return await namedApiResourceList
    //            .Select(x => GetResource<T>(x.Url))
    //            .ToListWhenAll();
    //    }

    //    public async Task<List<T>> GetDetails<T>(List<APIResource> apiResourceList)
    //    {
    //        return await apiResourceList
    //            .Select(x => GetResource<T>(x.Url))
    //            .ToListWhenAll();
    //    }









    //    ////        private async Task<T> GetResource<T>(string requestUri)
    //    ////            where T : IResource
    //    ////        {
    //    ////            var response = await Client.GetAsync(requestUri);
    //    ////            var json = await response.Content.ReadAsStringAsync();
    //    ////            var deserializedObject = JsonConvert.DeserializeObject<T>(json);

    //    ////            return deserializedObject;
    //    ////        }

    //    ////        public async Task<List<T>> LoadChildren<T>(List<APIResourceBase> listResults)
    //    ////            where T : APIResourceBase
    //    ////        {
    //    ////            var tasks = listResults
    //    ////                .Select(x => GetResource<T>(x.Url))
    //    ////                .ToList();

    //    ////            await Task.WhenAll(tasks);
    //    ////            var children = new List<T>(tasks.Select(x => x.Result));

    //    ////            return new List<T>(children);
    //    ////        }

    //    ////        public async Task<APIResourceList> GetGenerations()
    //    ////        {
    //    ////            var requestUri = "generations";
    //    ////            var results = await GetResource<APIResourceList>(requestUri);

    //    ////            return results;
    //    ////        }

    //    ////        //public async Task<APIResourceList<GenerationResource>> GetGenerationsIncludeChildren()
    //    ////        //{
    //    ////        //    var requestUri = "generations";
    //    ////        //    var results = await GetResource<APIResourceList>(requestUri);

    //    ////        //    if (loadChildren)
    //    ////        //        results.Results = await LoadChildren<GenerationResource>(results.Results);

    //    ////        //    return results;
    //    ////        //}

    //    ////        public async Task<Generation> GetGeneration(int id)
    //    ////        {
    //    ////            var requestUri = $"generations/{id}";
    //    ////            var result = await GetResource<Generation>(requestUri);

    //    ////            return result;
    //    ////        }

    //    ////        public async Task<Type> GetType(int id)
    //    ////        {
    //    ////            var requestUri = $"types/{id}";
    //    ////            var result = await GetResource<Type>(requestUri);

    //    ////            return result;
    //    ////        }
    //}
}
