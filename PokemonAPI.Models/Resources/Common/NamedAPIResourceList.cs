using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class NamedAPIResourceList : APIResourceListBase
    {
        /// <summary>
        /// A list of named API resources
        /// </summary>
        public List<NamedAPIResource> Results { get; set; }
    }
}