using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    /// <summary>
    /// A Pokédex is a handheld electronic encyclopedia device; one which is capable 
    /// of recording and retaining information of the various Pokémon in a given region 
    /// with the exception of the national dex and some smaller dexes related to 
    /// portions of a region. See Bulbapedia for greater detail.
    /// </summary>
    public class PokedexResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this Pokédex resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this Pokédex resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Whether or not this Pokédex originated in the main series of the video games
        /// </summary>
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The region this Pokédex catalogues Pokémon for
        /// </summary>
        public NamedAPIResource Region { get; set; }

        /// <summary>
        /// A list of version groups this Pokédex is relevant to
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

        /// <summary>
        /// The description of this Pokédex listed in different languages
        /// </summary>
        public List<DescriptionResource> Descriptions { get; set; }

        /// <summary>
        /// A list of Pokémon catalogued in this Pokédex and their indexes
        /// </summary>
        public List<PokemonEntryResource> PokemonEntries { get; set; }

        /// <summary>
        /// The name of this Pokédex listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }
    }
}