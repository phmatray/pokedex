namespace PokemonAPI.WebService.Models
{
    public partial class AbilityFlavorText
    {
        public int AbilityId { get; set; }
        public int VersionGroupId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual Abilities Ability { get; set; }
        public virtual Languages Language { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
