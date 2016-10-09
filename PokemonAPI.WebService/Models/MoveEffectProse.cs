namespace PokemonAPI.WebService.Models
{
    public partial class MoveEffectProse
    {
        public int MoveEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveEffects MoveEffect { get; set; }
    }
}
