using System.Linq;
using PokedexG.Uwp.Services.VeekunServices.Models;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public class PokemonSpeciesNamesRepo : RepositoryBase<PokemonSpeciesNamesRow>
    {
        public static PokemonSpeciesNamesRow Get(int pokemonSpeciesId, int localLanguageId)
        {
            return All.First(x => x.PokemonSpeciesId == pokemonSpeciesId &&
                                  x.LocalLanguageId == localLanguageId);
        }
    }
}