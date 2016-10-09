namespace PokemonAPI.WebService.Models
{
    public partial class AbilityProse
    {
        public int AbilityId { get; set; }
        public int LocalLanguageId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public virtual Abilities Ability { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
