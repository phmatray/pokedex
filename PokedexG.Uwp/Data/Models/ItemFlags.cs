using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFItemFlags : IEFIdentifier
    {
        public EFItemFlags()
        {
            ItemFlagMap = new HashSet<EFItemFlagMap>();
            ItemFlagProse = new HashSet<EFItemFlagProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFItemFlagMap> ItemFlagMap { get; set; }
        public ICollection<EFItemFlagProse> ItemFlagProse { get; set; }
    }
}
