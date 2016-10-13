using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFItemFlingEffects : IEFModel
    {
        public EFItemFlingEffects()
        {
            ItemFlingEffectProse = new HashSet<EFItemFlingEffectProse>();
            Items = new HashSet<EFItems>();
        }

        public int Id { get; set; }

        public virtual ICollection<EFItemFlingEffectProse> ItemFlingEffectProse { get; set; }
        public virtual ICollection<EFItems> Items { get; set; }
    }
}
