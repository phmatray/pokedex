using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ItemFlingEffects
    {
        public ItemFlingEffects()
        {
            ItemFlingEffectProse = new HashSet<ItemFlingEffectProse>();
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }

        public virtual ICollection<ItemFlingEffectProse> ItemFlingEffectProse { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
