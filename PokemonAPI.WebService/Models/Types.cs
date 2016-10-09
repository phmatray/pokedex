using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Types : INamedModel
    {
        public Types()
        {
            Berries = new HashSet<Berries>();
            ConquestKingdoms = new HashSet<ConquestKingdoms>();
            ConquestWarriorSpecialties = new HashSet<ConquestWarriorSpecialties>();
            ConquestWarriorTransformation = new HashSet<ConquestWarriorTransformation>();
            MoveChangelog = new HashSet<MoveChangelog>();
            Moves = new HashSet<Moves>();
            PokemonEvolutionKnownMoveType = new HashSet<PokemonEvolution>();
            PokemonEvolutionPartyType = new HashSet<PokemonEvolution>();
            PokemonTypes = new HashSet<PokemonTypes>();
            TypeEfficacyDamageType = new HashSet<TypeEfficacy>();
            TypeEfficacyTargetType = new HashSet<TypeEfficacy>();
            TypeGameIndices = new HashSet<TypeGameIndices>();
            TypeNames = new HashSet<TypeNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public int? DamageClassId { get; set; }

        public virtual ICollection<Berries> Berries { get; set; }
        public virtual ICollection<ConquestKingdoms> ConquestKingdoms { get; set; }
        public virtual ICollection<ConquestWarriorSpecialties> ConquestWarriorSpecialties { get; set; }
        public virtual ICollection<ConquestWarriorTransformation> ConquestWarriorTransformation { get; set; }
        public virtual ICollection<MoveChangelog> MoveChangelog { get; set; }
        public virtual ICollection<Moves> Moves { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolutionKnownMoveType { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolutionPartyType { get; set; }
        public virtual ICollection<PokemonTypes> PokemonTypes { get; set; }
        public virtual ICollection<TypeEfficacy> TypeEfficacyDamageType { get; set; }
        public virtual ICollection<TypeEfficacy> TypeEfficacyTargetType { get; set; }
        public virtual ICollection<TypeGameIndices> TypeGameIndices { get; set; }
        public virtual ICollection<TypeNames> TypeNames { get; set; }
        public virtual MoveDamageClasses DamageClass { get; set; }
        public virtual Generations Generation { get; set; }
    }
}
