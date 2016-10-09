using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Moves : INamedModel
    {
        public Moves()
        {
            ConquestPokemonMoves = new HashSet<ConquestPokemonMoves>();
            ContestCombosFirstMove = new HashSet<ContestCombos>();
            ContestCombosSecondMove = new HashSet<ContestCombos>();
            Machines = new HashSet<Machines>();
            MoveChangelog = new HashSet<MoveChangelog>();
            MoveFlagMap = new HashSet<MoveFlagMap>();
            MoveFlavorSummaries = new HashSet<MoveFlavorSummaries>();
            MoveFlavorText = new HashSet<MoveFlavorText>();
            MoveMetaStatChanges = new HashSet<MoveMetaStatChanges>();
            MoveNames = new HashSet<MoveNames>();
            PokemonEvolution = new HashSet<PokemonEvolution>();
            PokemonMoves = new HashSet<PokemonMoves>();
            SuperContestCombosFirstMove = new HashSet<SuperContestCombos>();
            SuperContestCombosSecondMove = new HashSet<SuperContestCombos>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public int TypeId { get; set; }
        public short? Power { get; set; }
        public short? Pp { get; set; }
        public short? Accuracy { get; set; }
        public short Priority { get; set; }
        public int TargetId { get; set; }
        public int DamageClassId { get; set; }
        public int EffectId { get; set; }
        public int? EffectChance { get; set; }
        public int? ContestTypeId { get; set; }
        public int? ContestEffectId { get; set; }
        public int? SuperContestEffectId { get; set; }

        public virtual ConquestMoveData ConquestMoveData { get; set; }
        public virtual ICollection<ConquestPokemonMoves> ConquestPokemonMoves { get; set; }
        public virtual ICollection<ContestCombos> ContestCombosFirstMove { get; set; }
        public virtual ICollection<ContestCombos> ContestCombosSecondMove { get; set; }
        public virtual ICollection<Machines> Machines { get; set; }
        public virtual ICollection<MoveChangelog> MoveChangelog { get; set; }
        public virtual ICollection<MoveFlagMap> MoveFlagMap { get; set; }
        public virtual ICollection<MoveFlavorSummaries> MoveFlavorSummaries { get; set; }
        public virtual ICollection<MoveFlavorText> MoveFlavorText { get; set; }
        public virtual MoveMeta MoveMeta { get; set; }
        public virtual ICollection<MoveMetaStatChanges> MoveMetaStatChanges { get; set; }
        public virtual ICollection<MoveNames> MoveNames { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolution { get; set; }
        public virtual ICollection<PokemonMoves> PokemonMoves { get; set; }
        public virtual ICollection<SuperContestCombos> SuperContestCombosFirstMove { get; set; }
        public virtual ICollection<SuperContestCombos> SuperContestCombosSecondMove { get; set; }
        public virtual ContestEffects ContestEffect { get; set; }
        public virtual ContestTypes ContestType { get; set; }
        public virtual MoveDamageClasses DamageClass { get; set; }
        public virtual MoveEffects Effect { get; set; }
        public virtual Generations Generation { get; set; }
        public virtual SuperContestEffects SuperContestEffect { get; set; }
        public virtual MoveTargets Target { get; set; }
        public virtual Types Type { get; set; }
    }
}
