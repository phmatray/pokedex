using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.CliCore
{
    public class Program
    {
        private static DateTime _start;

        public static void Main(string[] args)
        {
            //Directory.
            //var fileStream = File.Create("result.json");
            //File.






            Tests();
            Console.ReadKey();
        }

        public static async void Tests()
        {
            _start = DateTime.Now;
            DataFetcher.Config = new TestingConfig();

            WriteLine("Get Pokemons...");
            var pokemons = await DataFetcher.GetPokemons();
            var pokemonsCount = pokemons.Count;
            var count = 20;
            WriteLine($"{pokemonsCount} pokemons found.");
            Console.WriteLine("========================");


            _start = DateTime.Now;
            var results = new List<Pokemon>();
            for (int i = 0; i < count; i++)
            {
                var p = pokemons.Results[i];
                var pokemon = await DataFetcher.GetResource<Pokemon>(p.Url);
                results.Add(pokemon);
                WriteLine($"{i+1:D3}/{count} : {pokemon.Name} added");
            }
            var end = DateTime.Now - _start;
            WriteLine($"{end:g} elapsed");

            //var generations = await DataFetcher.GetGenerations();
            //var details     = await DataFetcher.GetGenerationDetails();

            //var generation  = await DataFetcher.GetGeneration(1);
            //var species     = await generation.PokemonSpecies.GetDetails<PokemonSpecies>();


            //var details2    = await df.GetGenerations().GetDetails();

            //var gen = generationDetails.First();
            //gen.PokemonSpecies.

            //var pokemonSpecies = generationDetails[0].PokemonSpecies.Load<PokemonSpecies>().Result;(
            //var pokemonSpecies = Load(generationDetails[0], x => x.PokemonSpecies).Result;
            //var pokemonSpecies = Fetch<PokemonSpecies>(generationDetails[0].PokemonSpecies).Result;

        }

        private static void WriteLine(string value)
        {
            Console.WriteLine($"{DateTime.Now-_start:g} - {value}");
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
