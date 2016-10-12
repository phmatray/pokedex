namespace PokemonAPI.Models.Rsc
{
    public class MoveStatChange
    {
        /// <summary>
        /// The amount of change
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// The stat being affected
        /// </summary>
        public NamedAPIResource Stat { get; set; }

    }
}