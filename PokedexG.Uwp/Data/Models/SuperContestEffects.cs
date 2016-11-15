using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFSuperContestEffects : IEFId
    {
        public EFSuperContestEffects()
        {
            Moves = new HashSet<EFMoves>();
            SuperContestEffectProse = new HashSet<EFSuperContestEffectProse>();
        }

        public int Id { get; set; }
        public short Appeal { get; set; }

        public ICollection<EFMoves> Moves { get; set; }
        public ICollection<EFSuperContestEffectProse> SuperContestEffectProse { get; set; }
    }
}
