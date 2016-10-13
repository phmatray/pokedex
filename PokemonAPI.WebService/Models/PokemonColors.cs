using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokemonColors : IEFModel, IEFIdentifier
    {
        public EFPokemonColors()
        {
            PokemonColorNames = new HashSet<EFPokemonColorNames>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFPokemonColorNames> PokemonColorNames { get; set; }
        public virtual ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
    }
}
