using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestMoveDisplacements : IEFModel, IEFIdentifier
    {
        public EFConquestMoveDisplacements()
        {
            ConquestMoveData = new HashSet<EFConquestMoveData>();
            ConquestMoveDisplacementProse = new HashSet<EFConquestMoveDisplacementProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public bool AffectsTarget { get; set; }

        public virtual ICollection<EFConquestMoveData> ConquestMoveData { get; set; }
        public virtual ICollection<EFConquestMoveDisplacementProse> ConquestMoveDisplacementProse { get; set; }
    }
}
