namespace PokemonAPI.Models.Resources
{
    public class GenusResource
    {
        /// <summary>
        /// The localized genus for the referenced Pokémon species
        /// </summary>
        public string Genus { get; set; }

        /// <summary>
        /// The language this genus is in
        /// </summary>
        public NamedAPIResource Language { get; set; }
    }
}