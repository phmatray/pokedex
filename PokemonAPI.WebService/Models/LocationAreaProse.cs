namespace PokemonAPI.WebService.Models
{
    public partial class LocationAreaProse
    {
        public int LocationAreaId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual LocationAreas LocationArea { get; set; }
    }
}
