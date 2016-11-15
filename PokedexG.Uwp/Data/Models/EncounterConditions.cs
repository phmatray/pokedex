using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFEncounterConditions : IEFIdentifier
    {
        public EFEncounterConditions()
        {
            EncounterConditionProse = new HashSet<EFEncounterConditionProse>();
            EncounterConditionValues = new HashSet<EFEncounterConditionValues>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFEncounterConditionProse> EncounterConditionProse { get; set; }
        public ICollection<EFEncounterConditionValues> EncounterConditionValues { get; set; }
    }
}
