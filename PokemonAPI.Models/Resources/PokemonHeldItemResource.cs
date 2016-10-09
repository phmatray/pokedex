using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class PokemonHeldItemResource
    {
        /// <summary>
        /// The item the referenced Pokémon holds
        /// </summary>
        public NamedAPIResource Item { get; set; }

        /// <summary>
        /// The details of the different versions in which the item is held
        /// </summary>
        public List<PokemonHeldItemVersionResource> VersionDetails { get; set; }
    }
}