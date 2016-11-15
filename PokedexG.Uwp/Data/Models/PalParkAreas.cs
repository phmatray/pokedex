using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFPalParkAreas : IEFIdentifier
    {
        public EFPalParkAreas()
        {
            PalPark = new HashSet<EFPalPark>();
            PalParkAreaNames = new HashSet<EFPalParkAreaNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFPalPark> PalPark { get; set; }
        public ICollection<EFPalParkAreaNames> PalParkAreaNames { get; set; }
    }
}
