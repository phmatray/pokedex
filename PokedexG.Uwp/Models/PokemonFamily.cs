using System.Collections.Generic;

namespace PokedexG.Uwp.Models
{
    public class PokemonFamily
    {
        public List<PokemonFamilyStade> EvolutionStades { get; set; } = new List<PokemonFamilyStade>();
    }
}