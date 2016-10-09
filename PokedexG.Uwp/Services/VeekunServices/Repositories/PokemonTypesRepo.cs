using System.Collections.Generic;
using System.Linq;
using PokedexG.Uwp.Services.VeekunServices.Models;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public class PokemonTypesRepo : RepositoryBase<PokemonTypesRow>
    {
        public static List<PokemonTypesRow> GetByPokemonId(int pokemonId)
        {
            return All
                .Where(x => x.PokemonId == pokemonId)
                .ToList();
        }
    }
}