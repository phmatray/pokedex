using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFSuperContestEffects : IEFModel
    {
        public EFSuperContestEffects()
        {
            Moves = new HashSet<EFMoves>();
            SuperContestEffectProse = new HashSet<EFSuperContestEffectProse>();
        }

        public int Id { get; set; }
        public short Appeal { get; set; }

        public virtual ICollection<EFMoves> Moves { get; set; }
        public virtual ICollection<EFSuperContestEffectProse> SuperContestEffectProse { get; set; }
    }
}
