using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class MoveTargets
    {
        public MoveTargets()
        {
            Moves = new HashSet<Moves>();
            MoveTargetProse = new HashSet<MoveTargetProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<Moves> Moves { get; set; }
        public virtual ICollection<MoveTargetProse> MoveTargetProse { get; set; }
    }
}
