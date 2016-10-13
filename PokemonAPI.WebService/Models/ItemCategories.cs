using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFItemCategories : IEFModel, IEFIdentifier
    {
        public EFItemCategories()
        {
            ItemCategoryProse = new HashSet<EFItemCategoryProse>();
            Items = new HashSet<EFItems>();
        }

        public int Id { get; set; }
        public int PocketId { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFItemCategoryProse> ItemCategoryProse { get; set; }
        public virtual ICollection<EFItems> Items { get; set; }
        public virtual EFItemPockets Pocket { get; set; }
    }
}
