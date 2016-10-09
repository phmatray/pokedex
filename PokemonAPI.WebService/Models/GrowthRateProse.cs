namespace PokemonAPI.WebService.Models
{
    public partial class GrowthRateProse
    {
        public int GrowthRateId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual GrowthRates GrowthRate { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
