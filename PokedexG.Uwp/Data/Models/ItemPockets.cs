using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFItemPockets : IEFIdentifier
    {
        public EFItemPockets()
        {
            ItemCategories = new HashSet<EFItemCategories>();
            ItemPocketNames = new HashSet<EFItemPocketNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFItemCategories> ItemCategories { get; set; }
        public ICollection<EFItemPocketNames> ItemPocketNames { get; set; }
    }
}
