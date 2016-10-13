using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEncounterSlots : IEFModel
    {
        public EFEncounterSlots()
        {
            Encounters = new HashSet<EFEncounters>();
        }

        public int Id { get; set; }
        public int VersionGroupId { get; set; }
        public int EncounterMethodId { get; set; }
        public int? Slot { get; set; }
        public int? Rarity { get; set; }

        public virtual ICollection<EFEncounters> Encounters { get; set; }
        public virtual EFEncounterMethods EncounterMethod { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
