using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFItemPockets : IEFModel, IEFIdentifier
    {
        public EFItemPockets()
        {
            ItemCategories = new HashSet<EFItemCategories>();
            ItemPocketNames = new HashSet<EFItemPocketNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFItemCategories> ItemCategories { get; set; }
        public virtual ICollection<EFItemPocketNames> ItemPocketNames { get; set; }
    }
}
