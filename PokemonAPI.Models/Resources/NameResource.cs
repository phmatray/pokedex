namespace PokemonAPI.Models.Resources
{
    public class NameResource
    {
        /// <summary>
        /// The localized name for an API resource in a specific language
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }
    }
}