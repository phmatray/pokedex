namespace PokemonAPI.Models.Resources
{
    public class PokemonHeldItemVersionResource
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