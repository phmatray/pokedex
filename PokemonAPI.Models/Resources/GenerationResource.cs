using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    /// <summary>
    /// A generation is a grouping of the Pokémon games that separates them based on the Pokémon
    /// they include. In each generation, a new set of Pokémon, Moves, Abilities and Types
    /// that did not exist in the previous generation are released.
    /// </summary>
    public class GenerationResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this generation resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this generation resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// A list of abilities that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> Abilities { get; set; }

        /// <summary>
        /// A list of version groups that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

        /// <summary>
        /// The name of this generation listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }

        /// <summary>
        /// A list of Pokémon species that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

        /// <summary>
        /// A list of moves that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

        /// <summary>
        /// The main region travelled in this generation
        /// </summary>
        public NamedAPIResource MainRegion { get; set; }

        /// <summary>
        /// A list of types that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> Types { get; set; }
    }
}