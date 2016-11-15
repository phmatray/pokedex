using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFItemNames : IEFModel
    {
        public int ItemId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFItems Item { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
