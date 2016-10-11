using System.Collections.Generic;

namespace PokemonAPI.Models.Resources
{
    /// <summary>
    /// Types are properties for Pokémon and their moves. Each type has three properties: 
    /// which types of Pokémon it is super effective against, which types of Pokémon it is not
    /// very effective against, and which types of Pokémon it is completely ineffective against.
    /// </summary>
    public class TypeResource : NamedAPIResource
    {
        /// <summary>
        /// The identifier for this type resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this type resource
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// A detail of how effective this type is toward others and vice versa
        /// </summary>
        public TypeRelationsResource DamageRelations { get; set; }

        ///// <summary>
        ///// A non-sorted list of how effective or non-effecive this type is toward others showing damage factors
        ///// </summary>
        //public List<TypeEfficacyResource> DamageFactors { get; set; }

        /// <summary>
        /// A list of game indices relevent to this item by generation
        /// </summary>
        public List<GenerationGameIndexResource> GameIndices { get; set; }

        /// <summary>
        /// The generation this type was introduced in
        /// </summary>
        public NamedAPIResource Generation { get; set; }

        /// <summary>
        /// The class of damage inflicted by this type
        /// </summary>
        public NamedAPIResource MoveDamageClass { get; set; }

        /// <summary>
        /// The name of this type listed in different languages
        /// </summary>
        public List<NameResource> Names { get; set; }

        /// <summary>
        /// A list of details of Pokémon that have this type
        /// </summary>
        public List<TypePokemonResource> Pokemon { get; set; }

        /// <summary>
        /// A list of moves that have this type
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

    }
}