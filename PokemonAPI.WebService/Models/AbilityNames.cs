namespace PokemonAPI.WebService.Models
{
    public partial class AbilityNames
    {
        public int AbilityId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Abilities Ability { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
