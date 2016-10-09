namespace PokemonAPI.Models.Resources
{
    public class TypePokemonResource
    {
        /// <summary>
        /// The order the Pokémon's types are listed in
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The Pokémon that has the referenced type
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }
    }
}