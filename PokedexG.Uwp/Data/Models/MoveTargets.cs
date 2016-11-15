using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFMoveTargets : IEFIdentifier
    {
        public EFMoveTargets()
        {
            Moves = new HashSet<EFMoves>();
            MoveTargetProse = new HashSet<EFMoveTargetProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFMoves> Moves { get; set; }
        public ICollection<EFMoveTargetProse> MoveTargetProse { get; set; }
    }
}
