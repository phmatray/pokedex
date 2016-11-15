using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFEncounterConditionValueMap : IEFModel
    {
        public int EncounterId { get; set; }
        public int EncounterConditionValueId { get; set; }

        public virtual EFEncounterConditionValues EncounterConditionValue { get; set; }
        public virtual EFEncounters Encounter { get; set; }
    }
}
