namespace PokemonAPI.WebService.Models
{
    public partial class SuperContestEffectProse
    {
        public int SuperContestEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual SuperContestEffects SuperContestEffect { get; set; }
    }
}
