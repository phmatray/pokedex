namespace PokemonAPI.Models.Rsc
{
    public class TypePokemon
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