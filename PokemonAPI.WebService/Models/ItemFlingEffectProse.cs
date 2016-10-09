namespace PokemonAPI.WebService.Models
{
    public partial class ItemFlingEffectProse
    {
        public int ItemFlingEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Effect { get; set; }

        public virtual ItemFlingEffects ItemFlingEffect { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
