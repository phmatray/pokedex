using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class Genders
    {
        public Genders()
        {
            ConquestPokemonEvolution = new HashSet<ConquestPokemonEvolution>();
            ConquestWarriors = new HashSet<ConquestWarriors>();
            PokemonEvolution = new HashSet<PokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<ConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual ICollection<ConquestWarriors> ConquestWarriors { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolution { get; set; }
    }
}
