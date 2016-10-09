using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    /// <summary>
    /// Growth rates are the speed with which Pokémon gain levels through experience.
    /// Check out Bulbapedia for greater detail.
    /// </summary>
    public class GrowthRateResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this growth rate resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this growth rate resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The formula used to calculate the rate at which the Pokémon species gains level
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// The descriptions of this characteristic listed in different languages
        /// </summary>
        public List<DescriptionResource> Descriptions { get; set; }

        /// <summary>
        /// A list of levels and the amount of experienced needed to atain
        /// them based on this growth rate
        /// </summary>
        public List<GrowthRateExperienceLevelResource> Levels { get; set; }

        /// <summary>
        /// A list of Pokémon species that gain levels at this growth rate
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }
    }
}