namespace PokemonAPI.Models.Rsc
{
    public class MoveStatAffect
    {
        /// <summary>
        /// The maximum amount of change to the referenced stat
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// The move causing the change
        /// </summary>
        public NamedAPIResource Move { get; set; }

    }
}