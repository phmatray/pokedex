using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestKingdoms
    {
        public ConquestKingdoms()
        {
            ConquestKingdomNames = new HashSet<ConquestKingdomNames>();
            ConquestPokemonEvolution = new HashSet<ConquestPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int TypeId { get; set; }

        public virtual ICollection<ConquestKingdomNames> ConquestKingdomNames { get; set; }
        public virtual ICollection<ConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual Types Type { get; set; }
    }
}
