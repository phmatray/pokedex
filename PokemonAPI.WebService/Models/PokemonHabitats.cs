using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokemonHabitats : IEFModel, IEFIdentifier
    {
        public EFPokemonHabitats()
        {
            PokemonHabitatNames = new HashSet<EFPokemonHabitatNames>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFPokemonHabitatNames> PokemonHabitatNames { get; set; }
        public virtual ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
    }
}
