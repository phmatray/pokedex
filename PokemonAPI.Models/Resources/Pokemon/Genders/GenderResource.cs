using System.Collections.Generic;

namespace PokemonAPI.Models.Resources.Pokemon.Genders
{
    /// <summary>
    /// Genders were introduced in Generation II for the purposes of breeding Pokémon 
    /// but can also result in visual differences or even different evolutionary lines. 
    /// Check out Bulbapedia for greater detail.
    /// </summary>
    public class GenderResource
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public List<PokemonSpeciesGenderResource> PokemonSpeciesDetails { get; set; }
        public List<NamedAPIResource> RequiredForEvolution { get; set; }
    }
}