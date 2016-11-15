using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFItemCategories : IEFIdentifier
    {
        public EFItemCategories()
        {
            ItemCategoryProse = new HashSet<EFItemCategoryProse>();
            Items = new HashSet<EFItems>();
        }

        public int Id { get; set; }
        public int PocketId { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFItemCategoryProse> ItemCategoryProse { get; set; }
        public ICollection<EFItems> Items { get; set; }
        public EFItemPockets Pocket { get; set; }
    }
}
