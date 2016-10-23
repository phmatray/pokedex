namespace PokemonAPI.Models.Rsc
{
    public class EncounterVersionDetails
    {
        /// <summary>
        /// The chance of an encounter to occur.
        /// </summary>
        public int? Rate { get; set; }

        /// <summary>
        /// The version of the game in which the encounter can occur with the given chance.
        /// </summary>
        public NamedAPIResource Version { get; set; }

    }
}