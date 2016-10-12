namespace PokemonAPI.Models.Rsc
{
    public class AbilityFlavorText
    {
        /// <summary>
        /// The localized name for an API resource in a specific language
        /// </summary>
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

        /// <summary>
        /// The version group that uses this flavor text
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}