namespace PokemonAPI.WebService.Models
{
    public partial class MoveEffectChangelogProse
    {
        public int MoveEffectChangelogId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Effect { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveEffectChangelog MoveEffectChangelog { get; set; }
    }
}
