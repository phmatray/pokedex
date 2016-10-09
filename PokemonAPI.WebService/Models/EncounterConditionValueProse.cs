namespace PokemonAPI.WebService.Models
{
    public partial class EncounterConditionValueProse
    {
        public int EncounterConditionValueId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EncounterConditionValues EncounterConditionValue { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
