namespace PokemonAPI.Models.Resources
{
    public class PokemonSpeciesVarietyResource
    {
        /// <summary>
        /// Whether this variety is the default variety
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// The Pokémon variety
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }
    }
}