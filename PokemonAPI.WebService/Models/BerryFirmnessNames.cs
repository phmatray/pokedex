namespace PokemonAPI.WebService.Models
{
    public partial class BerryFirmnessNames
    {
        public int BerryFirmnessId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual BerryFirmness BerryFirmness { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
