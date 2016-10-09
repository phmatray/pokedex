namespace PokemonAPI.Models.Resources
{
    public class FlavorTextResource
    {
        /// <summary>
        /// The localized flavor text for an API resource in a specific language
        /// </summary>
        public string FlavorText { get; set; }

        /// <summary>
        /// The version this flavor text is in
        /// </summary>
        public NamedAPIResource Version { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }
    }
}