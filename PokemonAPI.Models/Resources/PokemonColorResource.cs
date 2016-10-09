using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class PokemonColorResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this Pokémon color resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this Pokémon color resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of this Pokémon color listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }

        /// <summary>
        /// A list of the Pokémon species that have this color
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }
    }
}