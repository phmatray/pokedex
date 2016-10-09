namespace PokemonAPI.WebService.Models
{
    public partial class EncounterConditionValueMap
    {
        public int EncounterId { get; set; }
        public int EncounterConditionValueId { get; set; }

        public virtual EncounterConditionValues EncounterConditionValue { get; set; }
        public virtual Encounters Encounter { get; set; }
    }
}
