using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFAbilityChangelogProse : IEFModel
    {
        public int AbilityChangelogId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Effect { get; set; }

        public virtual EFAbilityChangelog AbilityChangelog { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
