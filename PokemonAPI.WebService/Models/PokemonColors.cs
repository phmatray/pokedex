using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokemonColors : INamedModel
    {
        public PokemonColors()
        {
            PokemonColorNames = new HashSet<PokemonColorNames>();
            PokemonSpecies = new HashSet<PokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<PokemonColorNames> PokemonColorNames { get; set; }
        public virtual ICollection<PokemonSpecies> PokemonSpecies { get; set; }
    }
}
