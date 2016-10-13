using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestStats : IEFModel, IEFIdentifier
    {
        public EFConquestStats()
        {
            ConquestPokemonEvolution = new HashSet<EFConquestPokemonEvolution>();
            ConquestPokemonStats = new HashSet<EFConquestPokemonStats>();
            ConquestStatNames = new HashSet<EFConquestStatNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public bool IsBase { get; set; }

        public virtual ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual ICollection<EFConquestPokemonStats> ConquestPokemonStats { get; set; }
        public virtual ICollection<EFConquestStatNames> ConquestStatNames { get; set; }
    }
}
