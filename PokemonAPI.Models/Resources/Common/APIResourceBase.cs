namespace PokemonAPI.Models.Resources
{
    public class APIResourceBase : IResource
    {
        /// <summary>
        /// The identfier of the referenced resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The URL of the referenced resource
        /// </summary>
        public string Url { get; set; }
    }
}