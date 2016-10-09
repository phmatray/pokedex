using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class EncounterSlots
    {
        public EncounterSlots()
        {
            Encounters = new HashSet<Encounters>();
        }

        public int Id { get; set; }
        public int VersionGroupId { get; set; }
        public int EncounterMethodId { get; set; }
        public int? Slot { get; set; }
        public int? Rarity { get; set; }

        public virtual ICollection<Encounters> Encounters { get; set; }
        public virtual EncounterMethods EncounterMethod { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
