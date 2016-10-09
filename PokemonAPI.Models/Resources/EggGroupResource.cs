using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class EggGroupResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this egg group resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this egg group resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The name of this egg group listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }

        /// <summary>
        /// A list of all Pokémon species that are members of this egg group
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }
    }
}