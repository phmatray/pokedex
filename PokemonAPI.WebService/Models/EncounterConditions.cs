using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class EncounterConditions
    {
        public EncounterConditions()
        {
            EncounterConditionProse = new HashSet<EncounterConditionProse>();
            EncounterConditionValues = new HashSet<EncounterConditionValues>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EncounterConditionProse> EncounterConditionProse { get; set; }
        public virtual ICollection<EncounterConditionValues> EncounterConditionValues { get; set; }
    }
}
