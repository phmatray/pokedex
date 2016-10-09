namespace PokemonAPI.Models.Resources
{
    public class APIResourceListBase : IResource
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
        /// he URL for the previous page in the list
        /// </summary>
        public string Previous { get; set; }
    }
}