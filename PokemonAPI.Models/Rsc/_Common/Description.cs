namespace PokemonAPI.Models.Rsc
{
    public class Description
    {
        /// <summary>
        /// The localized description for an API resource in a specific language
        /// </summary>
        public string DescriptionValue { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}