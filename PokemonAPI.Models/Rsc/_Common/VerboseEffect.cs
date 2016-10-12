namespace PokemonAPI.Models.Rsc
{
    public class VerboseEffect
    {
        /// <summary>
        /// The localized effect text for an API resource in a specific language
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// The localized effect text in brief
        /// </summary>
        public string ShortEffect { get; set; }

        /// <summary>
        /// The language this effect is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}