using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFLocationAreas : IEFModel, IEFIdentifier
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

        public virtual ICollection<EFEncounters> Encounters { get; set; }
        public virtual ICollection<EFLocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
        public virtual ICollection<EFLocationAreaProse> LocationAreaProse { get; set; }
        public virtual EFLocations Location { get; set; }
    }
}
