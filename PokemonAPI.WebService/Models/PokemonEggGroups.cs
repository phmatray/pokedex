namespace PokemonAPI.WebService.Models
{
    public partial class PokemonEggGroups
    {
        public int SpeciesId { get; set; }
        public int EggGroupId { get; set; }

        public virtual EggGroups EggGroup { get; set; }
        public virtual PokemonSpecies Species { get; set; }
    }
}
