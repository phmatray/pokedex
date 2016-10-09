using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    /// <summary>
    /// Pokémon are the creatures that inhabit the world of the Pokémon games. 
    /// They can be caught using Pokéballs and trained by battling with other Pokémon. 
    /// See Bulbapedia for greater detail.
    /// </summary>
    public class PokemonResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this Pokémon resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The human readable identifier for this Pokémon resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The base experience gained for defeating this Pokémon
        /// </summary>
        public int BaseExperience { get; set; }

        /// <summary>
        /// The height of this Pokémon
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Set for exactly one Pokémon used as the default for each species
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Order for sorting. Almost national order, except families are grouped together.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The weight of this Pokémon
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// A list of abilities this Pokémon could potentially have
        /// </summary>
        public List<PokemonAbilityResource> Abilities { get; set; }

        /// <summary>
        /// A list of forms this Pokémon can take on
        /// </summary>
        public List<NamedAPIResource> Forms { get; set; }

        /// <summary>
        /// A list of game indices relevent to Pokémon item by generation
        /// </summary>
        public List<VersionGameIndexResource> GameIndices { get; set; }

        /// <summary>
        /// A list of items this Pokémon may be holding when encountered
        /// </summary>
        public List<PokemonHeldItemResource> HeldItems { get; set; }

        /// <summary>
        /// A link to a list of location areas as well as encounter details pertaining to specific versions
        /// </summary>
        public string LocationAreaEncounters { get; set; }

        /// <summary>
        /// A list of moves along with learn methods and level details pertaining to specific version groups
        /// </summary>
        public List<PokemonMoveResource> Moves { get; set; }

        /// <summary>
        /// A set of sprites used to depict this Pokémon in the game
        /// </summary>
        public PokemonSpritesResource Sprites { get; set; }

        /// <summary>
        /// The species this Pokémon belongs to
        /// </summary>
        public NamedAPIResource Species { get; set; }

        /// <summary>
        /// A list of base stat values for this Pokémon
        /// </summary>
        public List<PokemonStatResource> Stats { get; set; }

        /// <summary>
        /// A list of details showing types this Pokémon has
        /// </summary>
        public List<PokemonTypeResource> Types { get; set; }
    }
}