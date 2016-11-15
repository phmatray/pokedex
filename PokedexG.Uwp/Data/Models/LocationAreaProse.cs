using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFLocationAreaProse : IEFModel
    {
        public int LocationAreaId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFLocationAreas LocationArea { get; set; }
    }
}
