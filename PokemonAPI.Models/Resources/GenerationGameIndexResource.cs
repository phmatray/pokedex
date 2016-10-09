namespace PokemonAPI.Models.Resources
{
    public class GenerationGameIndexResource
    {
        /// <summary>
        /// The internal id of an API resource within game data
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// The generation relevent to this game index
        /// </summary>
        public NamedAPIResource Generation { get; set; }
    }
}