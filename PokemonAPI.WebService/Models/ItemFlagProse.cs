namespace PokemonAPI.WebService.Models
{
    public partial class ItemFlagProse
    {
        public int ItemFlagId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ItemFlags ItemFlag { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
