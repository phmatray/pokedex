using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class EncounterMethodResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this encounter method resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this encounter method resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// A good value for sorting
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The name of this encounter method listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }
    }
}