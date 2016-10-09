using System.Collections.Generic;
using System.Linq;
using PokedexG.Uwp.Services.VeekunServices.Models;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public class TypeNamesRepo : RepositoryBase<TypeNamesRow>
    {
        public static TypeNamesRow Get(int typeId, int localLanguageId)
        {
            return All
                .Single(x => x.TypeId == typeId && x.LocalLanguageId == localLanguageId);
        }

        public static List<TypeNamesRow> GetByLocalLanguageId(int localLanguageId)
        {
            return All
                .Where(x => x.LocalLanguageId == localLanguageId)
                .ToList();
        }
    }
}