using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestStatNames : IEFModel
    {
        public int ConquestStatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFConquestStats ConquestStat { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
