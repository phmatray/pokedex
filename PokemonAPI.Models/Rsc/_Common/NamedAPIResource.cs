namespace PokemonAPI.Models.Rsc
{
    public class NamedAPIResource
    {
        public NamedAPIResource(string name, string url)
        {
            Name = name;
            Url = url;
        }

        /// <summary>
        /// The name of the referenced resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL of the referenced resource
        /// </summary>
        public string Url { get; set; }
    }
}