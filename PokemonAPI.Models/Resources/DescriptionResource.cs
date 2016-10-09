namespace PokemonAPI.Models.Resources
{
    public class DescriptionResource
    {
        /// <summary>
        /// The localized description for an API resource in a specific language
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }
    }
}