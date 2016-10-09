using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class EncounterConditionValues
    {
        public EncounterConditionValues()
        {
            EncounterConditionValueMap = new HashSet<EncounterConditionValueMap>();
            EncounterConditionValueProse = new HashSet<EncounterConditionValueProse>();
        }

        public int Id { get; set; }
        public int EncounterConditionId { get; set; }
        public string Identifier { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<EncounterConditionValueMap> EncounterConditionValueMap { get; set; }
        public virtual ICollection<EncounterConditionValueProse> EncounterConditionValueProse { get; set; }
        public virtual EncounterConditions EncounterCondition { get; set; }
    }
}
