namespace PokemonAPI.WebService.Models
{
    public partial class EvolutionTriggerProse
    {
        public int EvolutionTriggerId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EvolutionTriggers EvolutionTrigger { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
