namespace PokemonAPI.Models.Resources
{
    public class EffectResource
    {
        /// <summary>
        /// The localized effect text for an API resource in a specific language
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// The language this effect is in
        /// </summary>
        public NamedAPIResource Language { get; set; }
    }
}