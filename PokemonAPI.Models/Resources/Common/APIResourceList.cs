using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class APIResourceList : APIResourceListBase
    {
        /// <summary>
        /// A list of unnamed API resources
        /// </summary>
        public List<APIResourceBase> Results { get; set; }
    }

    public class APIResourceList<T> : APIResourceListBase
        where T : APIResourceBase
    {
        /// <summary>
        /// A list of unnamed API resources
        /// </summary>
        public List<T> Results { get; set; }
    }
}