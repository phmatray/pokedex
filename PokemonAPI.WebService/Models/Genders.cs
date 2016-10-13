using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFGenders : IEFModel, IEFIdentifier
    {
        public EFGenders()
        {
            ConquestPokemonEvolution = new HashSet<EFConquestPokemonEvolution>();
            ConquestWarriors = new HashSet<EFConquestWarriors>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual ICollection<EFConquestWarriors> ConquestWarriors { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
    }
}
