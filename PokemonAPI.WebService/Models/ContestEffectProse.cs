namespace PokemonAPI.WebService.Models
{
    public partial class ContestEffectProse
    {
        public int ContestEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorText { get; set; }
        public string Effect { get; set; }

        public virtual ContestEffects ContestEffect { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
