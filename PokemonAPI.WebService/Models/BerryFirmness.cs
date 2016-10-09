using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class BerryFirmness
    {
        public BerryFirmness()
        {
            Berries = new HashSet<Berries>();
            BerryFirmnessNames = new HashSet<BerryFirmnessNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<Berries> Berries { get; set; }
        public virtual ICollection<BerryFirmnessNames> BerryFirmnessNames { get; set; }
    }
}
