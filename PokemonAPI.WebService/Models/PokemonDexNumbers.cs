namespace PokemonAPI.WebService.Models
{
    public partial class PokemonDexNumbers
    {
        public int SpeciesId { get; set; }
        public int PokedexId { get; set; }
        public int PokedexNumber { get; set; }

        public virtual Pokedexes Pokedex { get; set; }
        public virtual PokemonSpecies Species { get; set; }
    }
}
