using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoves : IEFModel, IEFIdentifier
    {
        public EFMoves()
        {
            ConquestPokemonMoves = new HashSet<EFConquestPokemonMoves>();
            ContestCombosFirstMove = new HashSet<EFContestCombos>();
            ContestCombosSecondMove = new HashSet<EFContestCombos>();
            Machines = new HashSet<EFMachines>();
            MoveChangelog = new HashSet<EFMoveChangelog>();
            MoveFlagMap = new HashSet<EFMoveFlagMap>();
            MoveFlavorSummaries = new HashSet<EFMoveFlavorSummaries>();
            MoveFlavorText = new HashSet<EFMoveFlavorText>();
            MoveMetaStatChanges = new HashSet<EFMoveMetaStatChanges>();
            MoveNames = new HashSet<EFMoveNames>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            SuperContestCombosFirstMove = new HashSet<EFSuperContestCombos>();
            SuperContestCombosSecondMove = new HashSet<EFSuperContestCombos>();
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

        public virtual EFConquestMoveData ConquestMoveData { get; set; }
        public virtual ICollection<EFConquestPokemonMoves> ConquestPokemonMoves { get; set; }
        public virtual ICollection<EFContestCombos> ContestCombosFirstMove { get; set; }
        public virtual ICollection<EFContestCombos> ContestCombosSecondMove { get; set; }
        public virtual ICollection<EFMachines> Machines { get; set; }
        public virtual ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public virtual ICollection<EFMoveFlagMap> MoveFlagMap { get; set; }
        public virtual ICollection<EFMoveFlavorSummaries> MoveFlavorSummaries { get; set; }
        public virtual ICollection<EFMoveFlavorText> MoveFlavorText { get; set; }
        public virtual EFMoveMeta MoveMeta { get; set; }
        public virtual ICollection<EFMoveMetaStatChanges> MoveMetaStatChanges { get; set; }
        public virtual ICollection<EFMoveNames> MoveNames { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
        public virtual ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public virtual ICollection<EFSuperContestCombos> SuperContestCombosFirstMove { get; set; }
        public virtual ICollection<EFSuperContestCombos> SuperContestCombosSecondMove { get; set; }
        public virtual EFContestEffects ContestEffect { get; set; }
        public virtual EFContestTypes ContestType { get; set; }
        public virtual EFMoveDamageClasses DamageClass { get; set; }
        public virtual EFMoveEffects Effect { get; set; }
        public virtual EFGenerations Generation { get; set; }
        public virtual EFSuperContestEffects SuperContestEffect { get; set; }
        public virtual EFMoveTargets Target { get; set; }
        public virtual EFTypes Type { get; set; }
    }
}
