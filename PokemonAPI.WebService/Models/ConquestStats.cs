using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestStats
    {
        public ConquestStats()
        {
            ConquestPokemonEvolution = new HashSet<ConquestPokemonEvolution>();
            ConquestPokemonStats = new HashSet<ConquestPokemonStats>();
            ConquestStatNames = new HashSet<ConquestStatNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public bool IsBase { get; set; }

        public virtual ICollection<ConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual ICollection<ConquestPokemonStats> ConquestPokemonStats { get; set; }
        public virtual ICollection<ConquestStatNames> ConquestStatNames { get; set; }
    }
}
