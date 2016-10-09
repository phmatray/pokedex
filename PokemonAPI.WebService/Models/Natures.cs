using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class Natures
    {
        public Natures()
        {
            NatureBattleStylePreferences = new HashSet<NatureBattleStylePreferences>();
            NatureNames = new HashSet<NatureNames>();
            NaturePokeathlonStats = new HashSet<NaturePokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int DecreasedStatId { get; set; }
        public int IncreasedStatId { get; set; }
        public int HatesFlavorId { get; set; }
        public int LikesFlavorId { get; set; }
        public int GameIndex { get; set; }

        public virtual ICollection<NatureBattleStylePreferences> NatureBattleStylePreferences { get; set; }
        public virtual ICollection<NatureNames> NatureNames { get; set; }
        public virtual ICollection<NaturePokeathlonStats> NaturePokeathlonStats { get; set; }
        public virtual Stats DecreasedStat { get; set; }
        public virtual ContestTypes HatesFlavor { get; set; }
        public virtual Stats IncreasedStat { get; set; }
        public virtual ContestTypes LikesFlavor { get; set; }
    }
}
