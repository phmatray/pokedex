using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ContestEffects
    {
        public ContestEffects()
        {
            ContestEffectProse = new HashSet<ContestEffectProse>();
            Moves = new HashSet<Moves>();
        }

        public int Id { get; set; }
        public short Appeal { get; set; }
        public short Jam { get; set; }

        public virtual ICollection<ContestEffectProse> ContestEffectProse { get; set; }
        public virtual ICollection<Moves> Moves { get; set; }
    }
}
