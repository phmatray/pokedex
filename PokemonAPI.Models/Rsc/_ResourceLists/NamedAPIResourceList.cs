using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class NamedAPIResourceList
    {
        /// <summary>
        /// The total number of resources available from this API
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The URL for the next page in the list
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// The URL for the previous page in the list
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// A list of named API resources
        /// </summary>
        public List<NamedAPIResource> Results { get; set; }

    }
}