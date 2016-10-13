using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEncounterConditions : IEFModel, IEFIdentifier
    {
        public EFEncounterConditions()
        {
            EncounterConditionProse = new HashSet<EFEncounterConditionProse>();
            EncounterConditionValues = new HashSet<EFEncounterConditionValues>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFEncounterConditionProse> EncounterConditionProse { get; set; }
        public virtual ICollection<EFEncounterConditionValues> EncounterConditionValues { get; set; }
    }
}
