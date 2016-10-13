using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestMoveEffects : IEFModel
    {
        public EFConquestMoveEffects()
        {
            ConquestMoveData = new HashSet<EFConquestMoveData>();
            ConquestMoveEffectProse = new HashSet<EFConquestMoveEffectProse>();
        }

        public int Id { get; set; }

        public virtual ICollection<EFConquestMoveData> ConquestMoveData { get; set; }
        public virtual ICollection<EFConquestMoveEffectProse> ConquestMoveEffectProse { get; set; }
    }
}
