namespace PokemonAPI.WebService.Models
{
    public partial class NatureBattleStylePreferences
    {
        public int NatureId { get; set; }
        public int MoveBattleStyleId { get; set; }
        public int LowHpPreference { get; set; }
        public int HighHpPreference { get; set; }

        public virtual MoveBattleStyles MoveBattleStyle { get; set; }
        public virtual Natures Nature { get; set; }
    }
}
