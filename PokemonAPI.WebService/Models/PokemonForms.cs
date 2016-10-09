using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokemonForms : INamedModel
    {
        public PokemonForms()
        {
            PokemonFormGenerations = new HashSet<PokemonFormGenerations>();
            PokemonFormNames = new HashSet<PokemonFormNames>();
            PokemonFormPokeathlonStats = new HashSet<PokemonFormPokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public string FormIdentifier { get; set; }
        public int PokemonId { get; set; }
        public int? IntroducedInVersionGroupId { get; set; }
        public bool IsDefault { get; set; }
        public bool IsBattleOnly { get; set; }
        public bool IsMega { get; set; }
        public int FormOrder { get; set; }
        public int Order { get; set; }

        public virtual ICollection<PokemonFormGenerations> PokemonFormGenerations { get; set; }
        public virtual ICollection<PokemonFormNames> PokemonFormNames { get; set; }
        public virtual ICollection<PokemonFormPokeathlonStats> PokemonFormPokeathlonStats { get; set; }
        public virtual VersionGroups IntroducedInVersionGroup { get; set; }
        public virtual Pokemon Pokemon { get; set; }
    }
}
