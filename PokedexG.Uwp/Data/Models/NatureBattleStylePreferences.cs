using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFNatureBattleStylePreferences : IEFModel
    {
        public int NatureId { get; set; }
        public int MoveBattleStyleId { get; set; }
        public int LowHpPreference { get; set; }
        public int HighHpPreference { get; set; }

        public virtual EFMoveBattleStyles MoveBattleStyle { get; set; }
        public virtual EFNatures Nature { get; set; }
    }
}
