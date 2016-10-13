using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveTargets : IEFModel, IEFIdentifier
    {
        public EFMoveTargets()
        {
            Moves = new HashSet<EFMoves>();
            MoveTargetProse = new HashSet<EFMoveTargetProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFMoves> Moves { get; set; }
        public virtual ICollection<EFMoveTargetProse> MoveTargetProse { get; set; }
    }
}
