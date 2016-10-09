namespace PokemonAPI.WebService.Models
{
    public partial class LocationNames
    {
        public int LocationId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual Locations Location { get; set; }
    }
}
