using System.Linq;
using PokedexG.Uwp.Services.VeekunServices.Models;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public class PokemonSpeciesRepo : RepositoryBase<PokemonSpeciesRow>
    {
        public static PokemonSpeciesRow Get(int id)
        {
            return All.First(x => x.Id == id);
        }
    }
}