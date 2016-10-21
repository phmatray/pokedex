using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class APIResourceList
    {
        public APIResourceList(int count, string previous, string next, List<APIResource> results)
        {
            Count    = count;
            Previous = previous;
            Next     = next;
            Results  = results;
        }

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
        /// A list of unnamed API resources
        /// </summary>
        public List<APIResource> Results { get; set; }

    }
}
