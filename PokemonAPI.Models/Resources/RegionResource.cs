using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    /// <summary>
    /// A region is an organized area of the Pokémon world. Most often, the main difference between regions is the species of Pokémon that can be encountered within them.
    /// </summary>
    public class RegionResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this region resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this region resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// A list of locations that can be found in this region
        /// </summary>
        public List<NamedAPIResource> Locations { get; set; }

        /// <summary>
        /// A list of version groups where this region can be visited
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

        /// <summary>
        /// The name of this region listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }

        /// <summary>
        /// The generation this region was introduced in
        /// </summary>
        public NamedAPIResource MainGeneration { get; set; }

        /// <summary>
        /// A list of pokédexes that catalogue Pokémon in this region
        /// </summary>
        public List<NamedAPIResource> Pokedexes { get; set; }
    }
}