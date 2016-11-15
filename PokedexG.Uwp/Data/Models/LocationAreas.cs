using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFLocationAreas : IEFIdentifier
    {
        public EFLocationAreas()
        {
            Encounters = new HashSet<EFEncounters>();
            LocationAreaEncounterRates = new HashSet<EFLocationAreaEncounterRates>();
            LocationAreaProse = new HashSet<EFLocationAreaProse>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int GameIndex { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFEncounters> Encounters { get; set; }
        public ICollection<EFLocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
        public ICollection<EFLocationAreaProse> LocationAreaProse { get; set; }
        public EFLocations Location { get; set; }
    }
}
