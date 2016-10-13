using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFContestEffects : IEFModel
    {
        public EFContestEffects()
        {
            ContestEffectProse = new HashSet<EFContestEffectProse>();
            Moves = new HashSet<EFMoves>();
        }

        public int Id { get; set; }
        public short Appeal { get; set; }
        public short Jam { get; set; }

        public virtual ICollection<EFContestEffectProse> ContestEffectProse { get; set; }
        public virtual ICollection<EFMoves> Moves { get; set; }
    }
}
