using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFMoveBattleStyleProse : IEFModel
    {
        public int MoveBattleStyleId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoveBattleStyles MoveBattleStyle { get; set; }
    }
}
