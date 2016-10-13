using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFItemFlags : IEFModel, IEFIdentifier
    {
        public EFItemFlags()
        {
            ItemFlagMap = new HashSet<EFItemFlagMap>();
            ItemFlagProse = new HashSet<EFItemFlagProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFItemFlagMap> ItemFlagMap { get; set; }
        public virtual ICollection<EFItemFlagProse> ItemFlagProse { get; set; }
    }
}
