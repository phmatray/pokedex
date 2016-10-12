using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class EncounterMethodRate
    {
        /// <summary>
        /// The method in which Pokémon may be encountered in an area.
        /// </summary>
        public NamedAPIResource EncounterMethod { get; set; }

        /// <summary>
        /// The chance of the encounter to occur on a version of the game.
        /// </summary>
        public List<EncounterVersionDetails> VersionDetails { get; set; }

    }
}