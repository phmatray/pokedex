using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEncounterConditionValues : IEFModel, IEFIdentifier
    {
        public EFEncounterConditionValues()
        {
            EncounterConditionValueMap = new HashSet<EFEncounterConditionValueMap>();
            EncounterConditionValueProse = new HashSet<EFEncounterConditionValueProse>();
        }

        public int Id { get; set; }
        public int EncounterConditionId { get; set; }
        public string Identifier { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<EFEncounterConditionValueMap> EncounterConditionValueMap { get; set; }
        public virtual ICollection<EFEncounterConditionValueProse> EncounterConditionValueProse { get; set; }
        public virtual EFEncounterConditions EncounterCondition { get; set; }
    }
}
