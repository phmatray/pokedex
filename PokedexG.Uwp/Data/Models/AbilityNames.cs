using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFAbilityNames : IEFModel
    {
        public int AbilityId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFAbilities Ability { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
