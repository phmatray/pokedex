using System.Linq;
using PokedexG.Uwp.Services.VeekunServices.Models;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public class TypesRepo : RepositoryBase<TypesRow>
    {
        public static TypesRow Get(int id)
        {
            return All.First(x => x.Id == id);
        }
    }
}