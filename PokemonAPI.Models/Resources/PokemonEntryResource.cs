namespace PokemonAPI.Models.Resources
{
    public class PokemonEntryResource
    {
        /// <summary>
        /// The index of this Pokémon species entry within the Pokédex
        /// </summary>
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pokémon species being encountered
        /// </summary>
        public NamedAPIResource PokemonSpecies { get; set; }
    }
}