namespace PokemonAPI.Models.Rsc
{
    public class Name
    {
        /// <summary>
        /// The localized name for an API resource in a specific language
        /// </summary>
        public string NameValue { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}