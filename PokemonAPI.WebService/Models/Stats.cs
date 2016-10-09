using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Stats : INamedModel
    {
        public Stats()
        {
            Characteristics = new HashSet<Characteristics>();
            MoveMetaStatChanges = new HashSet<MoveMetaStatChanges>();
            NaturesDecreasedStat = new HashSet<Natures>();
            NaturesIncreasedStat = new HashSet<Natures>();
            PokemonStats = new HashSet<PokemonStats>();
            StatNames = new HashSet<StatNames>();
        }

        public int Id { get; set; }
        public int? DamageClassId { get; set; }
        public string Identifier { get; set; }
        public bool IsBattleOnly { get; set; }
        public int? GameIndex { get; set; }

        public virtual ICollection<Characteristics> Characteristics { get; set; }
        public virtual ICollection<MoveMetaStatChanges> MoveMetaStatChanges { get; set; }
        public virtual ICollection<Natures> NaturesDecreasedStat { get; set; }
        public virtual ICollection<Natures> NaturesIncreasedStat { get; set; }
        public virtual ICollection<PokemonStats> PokemonStats { get; set; }
        public virtual ICollection<StatNames> StatNames { get; set; }
        public virtual MoveDamageClasses DamageClass { get; set; }
    }
}
