using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class VersionEncounterDetail
    {
        /// <summary>
        /// The game version this encounter happens in
        /// </summary>
        public NamedAPIResource Version { get; set; }

        /// <summary>
        /// The total percentage of all encounter potential
        /// </summary>
        public int MaxChance { get; set; }

        /// <summary>
        /// A list of encounters and their specifics
        /// </summary>
        public List<Encounter> EncounterDetails { get; set; }

    }
}