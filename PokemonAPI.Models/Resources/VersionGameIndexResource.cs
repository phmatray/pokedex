namespace PokemonAPI.Models.Resources
{
    public class VersionGameIndexResource
    {
        /// <summary>
        /// The internal id of an API resource within game data
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// The version relevent to this game index
        /// </summary>
        public NamedAPIResource Version { get; set; }
    }
}