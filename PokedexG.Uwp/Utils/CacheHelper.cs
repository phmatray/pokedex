using System;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.Toolkit.Uwp;
using Newtonsoft.Json;

namespace PokedexG.Uwp.Utils
{
    public static class CacheHelper
    {
        public static async Task ClearLocalCacheFolder()
        {
            var localCacheFolder = ApplicationData.Current.LocalCacheFolder;
            var files = await localCacheFolder.GetFilesAsync();

            foreach (var file in files)
                await file.DeleteAsync();
        }

        public static async Task ClearLocalFolder()
        {
            var localCacheFolder = ApplicationData.Current.LocalFolder;
            var files = await localCacheFolder.GetFilesAsync();

            foreach (var file in files)
                await file.DeleteAsync();
        }

        //public static async Task<List<Pokemon>> GetPokemons()
        //{
        //    string fileName = $"pokemons{Constants.DbVersion}.txt";

        //    try
        //    {
        //        return await ReadFromCache<List<Pokemon>>(fileName);
        //    }
        //    catch (Exception)
        //    {
        //        var pokemons = await Veekun.GetPokemons();
        //        await WriteInCache(fileName, pokemons);
        //        return pokemons;
        //    }
        //}

        private static async Task WriteInCache<T>(string fileName, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            await StorageFileHelper.WriteTextToLocalCacheFileAsync(json, fileName);
        }

        private static async Task<T> ReadFromCache<T>(string fileName)
        {
            var fileContent = await StorageFileHelper.ReadTextFromLocalCacheFileAsync(fileName);
            if (fileContent == "[]")
                throw new Exception("file is empty");
            var deserializeObject = JsonConvert.DeserializeObject<T>(fileContent);
            return deserializeObject;
        }
    }
}