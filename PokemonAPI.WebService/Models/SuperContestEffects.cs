using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class SuperContestEffects
    {
        public SuperContestEffects()
        {
            Moves = new HashSet<Moves>();
            SuperContestEffectProse = new HashSet<SuperContestEffectProse>();
        }

        public int Id { get; set; }
        public short Appeal { get; set; }

        public virtual ICollection<Moves> Moves { get; set; }
        public virtual ICollection<SuperContestEffectProse> SuperContestEffectProse { get; set; }
    }
}
