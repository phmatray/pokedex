using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveEffects : IEFModel
    {
        public EFMoveEffects()
        {
            MoveChangelog = new HashSet<EFMoveChangelog>();
            MoveEffectChangelog = new HashSet<EFMoveEffectChangelog>();
            MoveEffectProse = new HashSet<EFMoveEffectProse>();
            Moves = new HashSet<EFMoves>();
        }

        public int Id { get; set; }

        public virtual ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public virtual ICollection<EFMoveEffectChangelog> MoveEffectChangelog { get; set; }
        public virtual ICollection<EFMoveEffectProse> MoveEffectProse { get; set; }
        public virtual ICollection<EFMoves> Moves { get; set; }
    }
}
