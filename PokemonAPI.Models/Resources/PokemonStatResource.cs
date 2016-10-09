namespace PokemonAPI.Models.Resources
{
    public class PokemonStatResource
    {
        /// <summary>
        /// The stat the Pokémon has
        /// </summary>
        public NamedAPIResource Stat { get; set; }

        /// <summary>
        /// The effort points (EV) the Pokémon has in the stat
        /// </summary>
        public int Effort { get; set; }

        /// <summary>
        /// The base value of the stat
        /// </summary>
        public int BaseStat { get; set; }
    }
}