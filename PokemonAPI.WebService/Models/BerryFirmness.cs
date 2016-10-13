using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFBerryFirmness : IEFModel, IEFIdentifier
    {
        public EFBerryFirmness()
        {
            Berries = new HashSet<EFBerries>();
            BerryFirmnessNames = new HashSet<EFBerryFirmnessNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFBerries> Berries { get; set; }
        public virtual ICollection<EFBerryFirmnessNames> BerryFirmnessNames { get; set; }
    }
}
