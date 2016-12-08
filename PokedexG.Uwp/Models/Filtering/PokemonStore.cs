using System.Collections.Generic;
using System.Threading.Tasks;
using PokedexG.Uwp.Services.VeekunServices;

#pragma warning disable 1998

namespace PokedexG.Uwp.Models.Filtering
{
    /// <summary>
    /// Implementation of the PokemonStore - this is a basic
    /// CRUD type store.
    /// </summary>
    public class PokemonStore : Store<Pokemon>
    {
        public static async Task<PokemonStore> Load()
        {
            var pokemons = await Veekun.GetPokemonsAsync();
            return new PokemonStore(pokemons);
        }

        private PokemonStore(IEnumerable<Pokemon> collection)
            : base(collection)
        {
        }

        public override async Task Create(Pokemon item)
        {
            Add(item);
        }

        public override async Task Update(Pokemon item)
        {
            for (var idx = 0; idx < Count; idx++)
            {
                if (Items[idx].PokemonId.Equals(item.PokemonId))
                    Items[idx] = item;
            }
        }

        public override async Task Delete(Pokemon item)
        {
            Remove(item);
        }
    }
}