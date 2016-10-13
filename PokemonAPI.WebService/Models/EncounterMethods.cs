using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEncounterMethods : IEFModel, IEFIdentifier
    {
        public EFEncounterMethods()
        {
            EncounterMethodProse = new HashSet<EFEncounterMethodProse>();
            EncounterSlots = new HashSet<EFEncounterSlots>();
            LocationAreaEncounterRates = new HashSet<EFLocationAreaEncounterRates>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int Order { get; set; }

        public virtual ICollection<EFEncounterMethodProse> EncounterMethodProse { get; set; }
        public virtual ICollection<EFEncounterSlots> EncounterSlots { get; set; }
        public virtual ICollection<EFLocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
    }
}
