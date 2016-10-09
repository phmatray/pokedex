using System.Collections.Generic;

namespace PokedexG.Uwp.Models
{
    public class PokemonFamilyStade
    {
        public string Name { get; set; }
        public List<PokemonEvolution> Evolutions { get; set; }
    }
}