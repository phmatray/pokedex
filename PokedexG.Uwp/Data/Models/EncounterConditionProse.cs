using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFEncounterConditionProse : IEFModel
    {
        public int EncounterConditionId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFEncounterConditions EncounterCondition { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
