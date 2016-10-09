namespace PokemonAPI.WebService.Models
{
    public partial class Experience
    {
        public int GrowthRateId { get; set; }
        public int Level { get; set; }
        public int Experience1 { get; set; }

        public virtual GrowthRates GrowthRate { get; set; }
    }
}
