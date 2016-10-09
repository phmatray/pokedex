namespace PokemonAPI.WebService.Models
{
    public partial class PokemonHabitatNames
    {
        public int PokemonHabitatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokemonHabitats PokemonHabitat { get; set; }
    }
}
