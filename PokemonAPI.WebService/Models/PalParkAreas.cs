using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PalParkAreas : INamedModel
    {
        public PalParkAreas()
        {
            PalPark = new HashSet<PalPark>();
            PalParkAreaNames = new HashSet<PalParkAreaNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<PalPark> PalPark { get; set; }
        public virtual ICollection<PalParkAreaNames> PalParkAreaNames { get; set; }
    }
}
