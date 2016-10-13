namespace PokemonAPI.Models.Rsc
{
    public class FlavorText
    {
        /// <summary>
        /// The localized flavor text for an API resource in a specific language
        /// </summary>
        public string FlavorTextValue { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

        public NamedAPIResource Version { get; set; }
    }
}