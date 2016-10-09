namespace PokemonAPI.WebService.Models
{
    public partial class LocationAreaEncounterRates
    {
        public int LocationAreaId { get; set; }
        public int EncounterMethodId { get; set; }
        public int VersionId { get; set; }
        public int? Rate { get; set; }

        public virtual EncounterMethods EncounterMethod { get; set; }
        public virtual LocationAreas LocationArea { get; set; }
        public virtual Versions Version { get; set; }
    }
}
