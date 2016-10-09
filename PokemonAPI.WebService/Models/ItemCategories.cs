using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ItemCategories
    {
        public ItemCategories()
        {
            ItemCategoryProse = new HashSet<ItemCategoryProse>();
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public int PocketId { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<ItemCategoryProse> ItemCategoryProse { get; set; }
        public virtual ICollection<Items> Items { get; set; }
        public virtual ItemPockets Pocket { get; set; }
    }
}
