namespace PokemonAPI.WebService.Models
{
    public partial class EncounterConditionProse
    {
        public int EncounterConditionId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EncounterConditions EncounterCondition { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
