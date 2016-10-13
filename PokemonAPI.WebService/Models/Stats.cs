using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFStats : IEFModel, IEFIdentifier
    {
        public EFStats()
        {
            Characteristics = new HashSet<EFCharacteristics>();
            MoveMetaStatChanges = new HashSet<EFMoveMetaStatChanges>();
            NaturesDecreasedStat = new HashSet<EFNatures>();
            NaturesIncreasedStat = new HashSet<EFNatures>();
            PokemonStats = new HashSet<EFPokemonStats>();
            StatNames = new HashSet<EFStatNames>();
        }

        public int Id { get; set; }
        public int? DamageClassId { get; set; }
        public string Identifier { get; set; }
        public bool IsBattleOnly { get; set; }
        public int? GameIndex { get; set; }

        public virtual ICollection<EFCharacteristics> Characteristics { get; set; }
        public virtual ICollection<EFMoveMetaStatChanges> MoveMetaStatChanges { get; set; }
        public virtual ICollection<EFNatures> NaturesDecreasedStat { get; set; }
        public virtual ICollection<EFNatures> NaturesIncreasedStat { get; set; }
        public virtual ICollection<EFPokemonStats> PokemonStats { get; set; }
        public virtual ICollection<EFStatNames> StatNames { get; set; }
        public virtual EFMoveDamageClasses DamageClass { get; set; }
    }
}
