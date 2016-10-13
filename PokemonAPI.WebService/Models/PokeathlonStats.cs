using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokeathlonStats : IEFModel, IEFIdentifier
    {
        public EFPokeathlonStats()
        {
            NaturePokeathlonStats = new HashSet<EFNaturePokeathlonStats>();
            PokeathlonStatNames = new HashSet<EFPokeathlonStatNames>();
            PokemonFormPokeathlonStats = new HashSet<EFPokemonFormPokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFNaturePokeathlonStats> NaturePokeathlonStats { get; set; }
        public virtual ICollection<EFPokeathlonStatNames> PokeathlonStatNames { get; set; }
        public virtual ICollection<EFPokemonFormPokeathlonStats> PokemonFormPokeathlonStats { get; set; }
    }
}
