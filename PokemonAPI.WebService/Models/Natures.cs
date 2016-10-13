using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFNatures : IEFModel, IEFIdentifier
    {
        public EFNatures()
        {
            NatureBattleStylePreferences = new HashSet<EFNatureBattleStylePreferences>();
            NatureNames = new HashSet<EFNatureNames>();
            NaturePokeathlonStats = new HashSet<EFNaturePokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int DecreasedStatId { get; set; }
        public int IncreasedStatId { get; set; }
        public int HatesFlavorId { get; set; }
        public int LikesFlavorId { get; set; }
        public int GameIndex { get; set; }

        public virtual ICollection<EFNatureBattleStylePreferences> NatureBattleStylePreferences { get; set; }
        public virtual ICollection<EFNatureNames> NatureNames { get; set; }
        public virtual ICollection<EFNaturePokeathlonStats> NaturePokeathlonStats { get; set; }
        public virtual EFStats DecreasedStat { get; set; }
        public virtual EFContestTypes HatesFlavor { get; set; }
        public virtual EFStats IncreasedStat { get; set; }
        public virtual EFContestTypes LikesFlavor { get; set; }
    }
}
