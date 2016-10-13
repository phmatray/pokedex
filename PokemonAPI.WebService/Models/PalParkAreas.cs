using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPalParkAreas : IEFModel, IEFIdentifier
    {
        public EFPalParkAreas()
        {
            PalPark = new HashSet<EFPalPark>();
            PalParkAreaNames = new HashSet<EFPalParkAreaNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFPalPark> PalPark { get; set; }
        public virtual ICollection<EFPalParkAreaNames> PalParkAreaNames { get; set; }
    }
}
