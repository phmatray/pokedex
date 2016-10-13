using System.Collections.Generic;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokemonForms : IEFModel, IEFIdentifier
    {
        public EFPokemonForms()
        {
            PokemonFormGenerations = new HashSet<EFPokemonFormGenerations>();
            PokemonFormNames = new HashSet<EFPokemonFormNames>();
            PokemonFormPokeathlonStats = new HashSet<EFPokemonFormPokeathlonStats>();
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

        public virtual ICollection<EFPokemonFormGenerations> PokemonFormGenerations { get; set; }
        public virtual ICollection<EFPokemonFormNames> PokemonFormNames { get; set; }
        public virtual ICollection<EFPokemonFormPokeathlonStats> PokemonFormPokeathlonStats { get; set; }
        public virtual EFVersionGroups IntroducedInVersionGroup { get; set; }
        public virtual EFPokemon Pokemon { get; set; }
    }
}
