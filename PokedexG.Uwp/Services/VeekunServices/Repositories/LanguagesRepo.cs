using System.Linq;
using PokedexG.Uwp.Services.VeekunServices.Models;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public class LanguagesRepo : RepositoryBase<LanguagesRow>
    {
        public static LanguagesRow Get(int id = Constants.DefaultLanguageId)
        {
            return All.First(x => x.Id == id);
        }
    }
}