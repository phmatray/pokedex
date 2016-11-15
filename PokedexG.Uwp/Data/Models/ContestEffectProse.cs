using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFContestEffectProse : IEFModel
    {
        public int ContestEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorText { get; set; }
        public string Effect { get; set; }

        public virtual EFContestEffects ContestEffect { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
