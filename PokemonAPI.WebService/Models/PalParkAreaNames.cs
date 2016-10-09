namespace PokemonAPI.WebService.Models
{
    public partial class PalParkAreaNames
    {
        public int PalParkAreaId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PalParkAreas PalParkArea { get; set; }
    }
}
