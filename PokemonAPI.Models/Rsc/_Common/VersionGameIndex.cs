namespace PokemonAPI.Models.Rsc
{
    public class VersionGameIndex
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