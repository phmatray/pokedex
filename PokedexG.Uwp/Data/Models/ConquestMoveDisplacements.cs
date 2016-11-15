using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFConquestMoveDisplacements : IEFIdentifier
    {
        public EFConquestMoveDisplacements()
        {
            ConquestMoveData = new HashSet<EFConquestMoveData>();
            ConquestMoveDisplacementProse = new HashSet<EFConquestMoveDisplacementProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public bool AffectsTarget { get; set; }

        public ICollection<EFConquestMoveData> ConquestMoveData { get; set; }
        public ICollection<EFConquestMoveDisplacementProse> ConquestMoveDisplacementProse { get; set; }
    }
}
