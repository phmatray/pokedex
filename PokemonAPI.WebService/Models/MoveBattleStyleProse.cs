namespace PokemonAPI.WebService.Models
{
    public partial class MoveBattleStyleProse
    {
        public int MoveBattleStyleId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveBattleStyles MoveBattleStyle { get; set; }
    }
}
