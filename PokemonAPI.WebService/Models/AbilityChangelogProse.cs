using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFAbilityChangelogProse : IEFModel
    {
        public int AbilityChangelogId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Effect { get; set; }

        public virtual EFAbilityChangelog AbilityChangelog { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
