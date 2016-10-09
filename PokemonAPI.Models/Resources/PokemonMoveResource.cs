using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class PokemonMoveResource
    {
        /// <summary>
        /// The move the Pokémon can learn
        /// </summary>
        public NamedAPIResource Move { get; set; }

        /// <summary>
        /// The details of the version in which the Pokémon can learn the move
        /// </summary>
        public List<PokemonMoveVersionResource> VersionGroupDetails { get; set; }
    }
}