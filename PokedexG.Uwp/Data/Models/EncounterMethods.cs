using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFEncounterMethods : IEFIdentifier
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

        public ICollection<EFEncounterMethodProse> EncounterMethodProse { get; set; }
        public ICollection<EFEncounterSlots> EncounterSlots { get; set; }
        public ICollection<EFLocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
    }
}
