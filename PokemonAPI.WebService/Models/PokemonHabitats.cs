using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokemonHabitats : INamedModel
    {
        public PokemonHabitats()
        {
            PokemonHabitatNames = new HashSet<PokemonHabitatNames>();
            PokemonSpecies = new HashSet<PokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<PokemonHabitatNames> PokemonHabitatNames { get; set; }
        public virtual ICollection<PokemonSpecies> PokemonSpecies { get; set; }
    }
}
