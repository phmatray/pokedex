using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    public class LocationAreaEncounterResource
    {
        /// <summary>
        /// The location area the referenced Pokémon can be encountered in
        /// </summary>
        public NamedAPIResource LocationArea { get; set; }

        /// <summary>
        /// A list of versions and encounters with the referenced Pokémon that might happen
        /// </summary>
        public List<VersionEncounterDetailResource> VersionDetails { get; set; }
    }
}