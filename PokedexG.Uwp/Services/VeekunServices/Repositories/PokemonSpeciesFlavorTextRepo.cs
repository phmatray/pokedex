using System.Linq;
using PokedexG.Uwp.Services.VeekunServices.Models;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public class PokemonSpeciesFlavorTextRepo : RepositoryBase<PokemonSpeciesFlavorTextRow>
    {
        public static PokemonSpeciesFlavorTextRow Get(int versionId, int speciesId, int languageId)
        {
            return All.First(x => x.VersionId == versionId &&
                                  x.SpeciesId == speciesId &&
                                  x.LanguageId == languageId);
        }
    }
}