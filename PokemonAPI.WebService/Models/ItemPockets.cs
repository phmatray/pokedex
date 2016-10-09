using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ItemPockets
    {
        public ItemPockets()
        {
            ItemCategories = new HashSet<ItemCategories>();
            ItemPocketNames = new HashSet<ItemPocketNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<ItemCategories> ItemCategories { get; set; }
        public virtual ICollection<ItemPocketNames> ItemPocketNames { get; set; }
    }
}
