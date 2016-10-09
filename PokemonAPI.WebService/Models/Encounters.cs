using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class Encounters
    {
        public Encounters()
        {
            EncounterConditionValueMap = new HashSet<EncounterConditionValueMap>();
        }

        public int Id { get; set; }
        public int VersionId { get; set; }
        public int LocationAreaId { get; set; }
        public int EncounterSlotId { get; set; }
        public int PokemonId { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }

        public virtual ICollection<EncounterConditionValueMap> EncounterConditionValueMap { get; set; }
        public virtual EncounterSlots EncounterSlot { get; set; }
        public virtual LocationAreas LocationArea { get; set; }
        public virtual Pokemon Pokemon { get; set; }
        public virtual Versions Version { get; set; }
    }
}
