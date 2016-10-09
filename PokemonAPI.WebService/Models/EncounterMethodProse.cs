namespace PokemonAPI.WebService.Models
{
    public partial class EncounterMethodProse
    {
        public int EncounterMethodId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EncounterMethods EncounterMethod { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
