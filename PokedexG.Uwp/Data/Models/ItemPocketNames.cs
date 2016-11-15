using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFItemPocketNames : IEFModel
    {
        public int ItemPocketId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFItemPockets ItemPocket { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
