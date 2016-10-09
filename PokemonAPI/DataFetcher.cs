using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonAPI.Models.Resources;

namespace PokemonAPI
{
    public class DataFetcher
    {
        public string SiteUrl { get; }
        public string BaseUrl { get; }
        public HttpClient Client { get; set; }

        public DataFetcher(string siteUrl = "http://localhost:50357", string baseUrl = "/api/v1/")
        {
            SiteUrl = siteUrl;
            BaseUrl = baseUrl;
            Client = new HttpClient {BaseAddress = new Uri($"{SiteUrl}{BaseUrl}")};
        }

        private async Task<T> GetResource<T>(string requestUri)
            where T : IResource
        {
            var response = await Client.GetAsync(requestUri);
            var json = await response.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<T>(json);

            return deserializedObject;
        }

        public async Task<List<T>> LoadChildren<T>(List<APIResourceBase> listResults)
            where T : APIResourceBase
        {
            var tasks = listResults
                .Select(x => GetResource<T>(x.Url))
                .ToList();

            await Task.WhenAll(tasks);
            var children = new List<T>(tasks.Select(x => x.Result));

            return new List<T>(children);
        }

        public async Task<APIResourceList> GetGenerations()
        {
            var requestUri = "generations";
            var results = await GetResource<APIResourceList>(requestUri);

            return results;
        }

        //public async Task<APIResourceList<GenerationResource>> GetGenerationsIncludeChildren()
        //{
        //    var requestUri = "generations";
        //    var results = await GetResource<APIResourceList>(requestUri);

        //    if (loadChildren)
        //        results.Results = await LoadChildren<GenerationResource>(results.Results);

        //    return results;
        //}

        public async Task<GenerationResource> GetGeneration(int id)
        {
            var requestUri = $"generations/{id}";
            var result = await GetResource<GenerationResource>(requestUri);

            return result;
        }

        public async Task<TypeResource> GetType(int id)
        {
            var requestUri = $"types/{id}";
            var result = await GetResource<TypeResource>(requestUri);

            return result;
        }
    }
}
