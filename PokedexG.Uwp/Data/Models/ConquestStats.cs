using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFConquestStats : IEFIdentifier
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

        public ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public ICollection<EFConquestPokemonStats> ConquestPokemonStats { get; set; }
        public ICollection<EFConquestStatNames> ConquestStatNames { get; set; }
    }
}
