namespace PokemonAPI.Models.Rsc
{
    public class ContestName
    {
        /// <summary>
        /// The name for this contest
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color associated with this contest's name
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The language that this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}