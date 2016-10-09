namespace PokemonAPI.WebService.Models
{
    public partial class MoveFlavorText
    {
        public int MoveId { get; set; }
        public int VersionGroupId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual Languages Language { get; set; }
        public virtual Moves Move { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
