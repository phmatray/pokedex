using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestMoveDisplacements
    {
        public ConquestMoveDisplacements()
        {
            ConquestMoveData = new HashSet<ConquestMoveData>();
            ConquestMoveDisplacementProse = new HashSet<ConquestMoveDisplacementProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public bool AffectsTarget { get; set; }

        public virtual ICollection<ConquestMoveData> ConquestMoveData { get; set; }
        public virtual ICollection<ConquestMoveDisplacementProse> ConquestMoveDisplacementProse { get; set; }
    }
}
