using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFContestTypeNames : IEFModel
    {
        public int ContestTypeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
        public string Color { get; set; }

        public virtual EFContestTypes ContestType { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
