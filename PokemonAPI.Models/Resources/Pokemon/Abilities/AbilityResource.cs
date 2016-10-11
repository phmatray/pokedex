using System.Collections.Generic;

namespace PokemonAPI.Models.Resources.Pokemon.Abilities
{
    public class AbilityResource
    {
        /// <summary>
        /// The identifier for this ability resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this ability resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Whether or not this ability originated in the main series of the video games
        /// </summary>
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The generation this ability originated in
        /// </summary>
        public NamedAPIResource Generation { get; set; }

        /// <summary>
        /// The name of this ability listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }

        /// <summary>
        /// The effect of this ability listed in different languages
        /// </summary>
        public List<VerboseEffectResource> EffectEntries { get; set; }

        /// <summary>
        /// The list of previous effects this ability has had across version groups
        /// </summary>
        public List<AbilityEffectChangeResource> EffectChanges { get; set; }

        /// <summary>
        /// The flavor text of this ability listed in different languages
        /// </summary>
        public List<AbilityFlavorTextResource> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of Pokémon that could potentially have this ability
        /// </summary>
        public List<AbilityPokemonResource> Pokemons { get; set; }
    }
}