using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFTypes : IEFModel, IEFIdentifier
    {
        public EFTypes()
        {
            Berries = new HashSet<EFBerries>();
            ConquestKingdoms = new HashSet<EFConquestKingdoms>();
            ConquestWarriorSpecialties = new HashSet<EFConquestWarriorSpecialties>();
            ConquestWarriorTransformation = new HashSet<EFConquestWarriorTransformation>();
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

        public virtual ICollection<EFBerries> Berries { get; set; }
        public virtual ICollection<EFConquestKingdoms> ConquestKingdoms { get; set; }
        public virtual ICollection<EFConquestWarriorSpecialties> ConquestWarriorSpecialties { get; set; }
        public virtual ICollection<EFConquestWarriorTransformation> ConquestWarriorTransformation { get; set; }
        public virtual ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public virtual ICollection<EFMoves> Moves { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolutionKnownMoveType { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolutionPartyType { get; set; }
        public virtual ICollection<EFPokemonTypes> PokemonTypes { get; set; }
        public virtual ICollection<EFTypeEfficacy> TypeEfficacyDamageType { get; set; }
        public virtual ICollection<EFTypeEfficacy> TypeEfficacyTargetType { get; set; }
        public virtual ICollection<EFTypeGameIndices> TypeGameIndices { get; set; }
        public virtual ICollection<EFTypeNames> TypeNames { get; set; }
        public virtual EFMoveDamageClasses DamageClass { get; set; }
        public virtual EFGenerations Generation { get; set; }
    }
}
