using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFGenders : IEFIdentifier
    {
        public EFGenders()
        {
            ConquestPokemonEvolution = new HashSet<EFConquestPokemonEvolution>();
            ConquestWarriors = new HashSet<EFConquestWarriors>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public ICollection<EFConquestWarriors> ConquestWarriors { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
    }
}
