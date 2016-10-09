using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    /// <summary>
    /// Versions of the games, e.g., Red, Blue or Yellow.
    /// </summary>
    public class VersionResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this version resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this version resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of this version listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }

        /// <summary>
        /// The version group this version belongs to
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }
    }
}