using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFEncounterMethodProse : IEFModel
    {
        public int EncounterMethodId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFEncounterMethods EncounterMethod { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
