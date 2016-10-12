namespace PokemonAPI.Models.Rsc
{
    public class Genus
    {
        /// <summary>
        /// The localized genus for the referenced Pokémon species
        /// </summary>
        public string GenusValue { get; set; }

        /// <summary>
        /// The language this genus is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}