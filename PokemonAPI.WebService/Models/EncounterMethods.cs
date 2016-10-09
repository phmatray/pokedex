using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class EncounterMethods
    {
        public EncounterMethods()
        {
            EncounterMethodProse = new HashSet<EncounterMethodProse>();
            EncounterSlots = new HashSet<EncounterSlots>();
            LocationAreaEncounterRates = new HashSet<LocationAreaEncounterRates>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int Order { get; set; }

        public virtual ICollection<EncounterMethodProse> EncounterMethodProse { get; set; }
        public virtual ICollection<EncounterSlots> EncounterSlots { get; set; }
        public virtual ICollection<LocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
    }
}
