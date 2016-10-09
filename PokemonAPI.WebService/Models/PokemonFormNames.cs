namespace PokemonAPI.WebService.Models
{
    public partial class PokemonFormNames
    {
        public int PokemonFormId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FormName { get; set; }
        public string PokemonName { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokemonForms PokemonForm { get; set; }
    }
}
