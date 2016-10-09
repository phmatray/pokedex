namespace PokemonAPI.WebService.Models
{
    public partial class MoveFlagProse
    {
        public int MoveFlagId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveFlags MoveFlag { get; set; }
    }
}
