using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestMoveEffects
    {
        public ConquestMoveEffects()
        {
            ConquestMoveData = new HashSet<ConquestMoveData>();
            ConquestMoveEffectProse = new HashSet<ConquestMoveEffectProse>();
        }

        public int Id { get; set; }

        public virtual ICollection<ConquestMoveData> ConquestMoveData { get; set; }
        public virtual ICollection<ConquestMoveEffectProse> ConquestMoveEffectProse { get; set; }
    }
}
