using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class PokeathlonStats
    {
        public PokeathlonStats()
        {
            NaturePokeathlonStats = new HashSet<NaturePokeathlonStats>();
            PokeathlonStatNames = new HashSet<PokeathlonStatNames>();
            PokemonFormPokeathlonStats = new HashSet<PokemonFormPokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<NaturePokeathlonStats> NaturePokeathlonStats { get; set; }
        public virtual ICollection<PokeathlonStatNames> PokeathlonStatNames { get; set; }
        public virtual ICollection<PokemonFormPokeathlonStats> PokemonFormPokeathlonStats { get; set; }
    }
}
