namespace PokemonAPI.Models.Rsc
{
    public class NaturePokeathlonStatAffect
    {
        /// <summary>
        /// The maximum amount of change to the referenced Pokéathlon stat
        /// </summary>
        public int MaxChange { get; set; }

        /// <summary>
        /// The nature causing the change
        /// </summary>
        public NamedAPIResource Nature { get; set; }

    }
}