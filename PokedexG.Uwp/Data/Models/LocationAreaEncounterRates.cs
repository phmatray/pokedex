using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFLocationAreaEncounterRates : IEFModel
    {
        public int LocationAreaId { get; set; }
        public int EncounterMethodId { get; set; }
        public int VersionId { get; set; }
        public int? Rate { get; set; }

        public virtual EFEncounterMethods EncounterMethod { get; set; }
        public virtual EFLocationAreas LocationArea { get; set; }
        public virtual EFVersions Version { get; set; }
    }
}
