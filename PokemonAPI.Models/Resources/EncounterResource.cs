using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class EncounterResource
    {
        /// <summary>
        /// The lowest level the Pokémon could be encountered at
        /// </summary>
        public int MinLevel { get; set; }

        /// <summary>
        /// The highest level the Pokémon could be encountered at
        /// </summary>
        public int MaxLevel { get; set; }

        /// <summary>
        /// A list of condition values that must be in effect for this encounter to occur
        /// </summary>
        public List<NamedAPIResource> ConditionValues { get; set; }

        /// <summary>
        /// percent chance that this encounter will occur
        /// </summary>
        public int Chance { get; set; }

        /// <summary>
        /// The method by which this encounter happens
        /// </summary>
        public EncounterMethodResource Method { get; set; }
    }
}