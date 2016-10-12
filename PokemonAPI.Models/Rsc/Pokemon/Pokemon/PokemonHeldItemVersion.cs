namespace PokemonAPI.Models.Rsc
{
    public class PokemonHeldItemVersion
    {
        /// <summary>
        /// The version in which the item is held
        /// </summary>
        public NamedAPIResource Version { get; set; }

        /// <summary>
        /// How often the item is held
        /// </summary>
        public int Rarity { get; set; }

    }
}