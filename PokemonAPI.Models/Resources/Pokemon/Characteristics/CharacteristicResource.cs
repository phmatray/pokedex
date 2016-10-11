using System.Collections.Generic;

namespace PokemonAPI.Models.Resources.Pokemon.Characteristics
{
    /// <summary>
    /// Characteristics indicate which stat contains a Pokémon's highest IV. 
    /// A Pokémon's Characteristic is determined by the remainder of its highest
    /// IV divided by 5 (gene_modulo). Check out Bulbapedia for greater detail.
    /// </summary>
    public class CharacteristicResource
    {
        /// <summary>
        /// The identifier for this characteristic resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The remainder of the highest stat/IV divided by 5
        /// </summary>
        public int GeneModulo { get; set; }

        /// <summary>
        /// The possible values of the highest stat that would result in 
        /// a Pokémon recieving this characteristic when divided by 5
        /// </summary>
        public List<int> PossibleValues { get; set; }

        /// <summary>
        /// The descriptions of this characteristic listed in different languages
        /// </summary>
        public List<DescriptionResource> Descriptions { get; set; }
    }
}