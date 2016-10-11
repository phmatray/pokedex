using System.Collections.Generic;

namespace PokemonAPI.Models.Resources.Pokemon.Abilities
{
    public class AbilityEffectChangeResource
    {
        /// <summary>
        /// The previous effect of this ability listed in different languages
        /// </summary>
        public List<EffectResource> EffectEntries { get; set; }

        /// <summary>
        /// The version group in which the previous effect of this ability originated
        /// </summary>
        public VersionGroupResource VersionGroup { get; set; }
    }
}