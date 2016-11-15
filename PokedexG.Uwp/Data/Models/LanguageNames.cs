using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFLanguageNames : IEFModel 
    {
        public int LanguageId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages Language { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
