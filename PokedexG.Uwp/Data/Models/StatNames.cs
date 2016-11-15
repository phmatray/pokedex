using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFStatNames : IEFModel
    {
        public int StatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFStats Stat { get; set; }
    }
}
