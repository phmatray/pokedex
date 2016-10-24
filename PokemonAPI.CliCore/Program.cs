using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.CliCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tests();
            Console.ReadKey();
        }

        public static async void Tests()
        {
            DataFetcher.Config = new TestingConfig();

            var generations = await DataFetcher.GetGenerations();
            var details     = await DataFetcher.GetGenerationDetails();

            var generation  = await DataFetcher.GetGeneration(1);
            var species     = await generation.PokemonSpecies.GetDetails<PokemonSpecies>();


            //var details2    = await df.GetGenerations().GetDetails();

            //var gen = generationDetails.First();
            //gen.PokemonSpecies.

            //var pokemonSpecies = generationDetails[0].PokemonSpecies.Load<PokemonSpecies>().Result;(
            //var pokemonSpecies = Load(generationDetails[0], x => x.PokemonSpecies).Result;
            //var pokemonSpecies = Fetch<PokemonSpecies>(generationDetails[0].PokemonSpecies).Result;

        }

        private static async Task<List<T>> Fetch<T>(List<NamedAPIResource> pokemonSpecies)
        {
            throw new NotImplementedException();
        }

        //private static async Task<List<TResult>> Load<TSource, TResult>(Generation generation, Func<TSource, TResult> selector)
        //{
        //    generation.PokemonSpecies
        //    throw new NotImplementedException();
        //}
    }
}
