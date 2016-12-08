using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFTypes : IEFIdentifier
    {
        public EFTypes()
        {
            Berries = new HashSet<EFBerries>();
            MoveChangelog = new HashSet<EFMoveChangelog>();
            Moves = new HashSet<EFMoves>();
            PokemonEvolutionKnownMoveType = new HashSet<EFPokemonEvolution>();
            PokemonEvolutionPartyType = new HashSet<EFPokemonEvolution>();
            PokemonTypes = new HashSet<EFPokemonTypes>();
            TypeEfficacyDamageType = new HashSet<EFTypeEfficacy>();
            TypeEfficacyTargetType = new HashSet<EFTypeEfficacy>();
            TypeGameIndices = new HashSet<EFTypeGameIndices>();
            TypeNames = new HashSet<EFTypeNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public int? DamageClassId { get; set; }

        public ICollection<EFBerries> Berries { get; set; }
        public ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public ICollection<EFMoves> Moves { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolutionKnownMoveType { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolutionPartyType { get; set; }
        public ICollection<EFPokemonTypes> PokemonTypes { get; set; }
        public ICollection<EFTypeEfficacy> TypeEfficacyDamageType { get; set; }
        public ICollection<EFTypeEfficacy> TypeEfficacyTargetType { get; set; }
        public ICollection<EFTypeGameIndices> TypeGameIndices { get; set; }
        public ICollection<EFTypeNames> TypeNames { get; set; }
        public EFMoveDamageClasses DamageClass { get; set; }
        public EFGenerations Generation { get; set; }
    }
}
