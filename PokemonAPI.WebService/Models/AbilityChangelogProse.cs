namespace PokemonAPI.WebService.Models
{
    public partial class AbilityChangelogProse
    {
        public int AbilityChangelogId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Effect { get; set; }

        public virtual AbilityChangelog AbilityChangelog { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
