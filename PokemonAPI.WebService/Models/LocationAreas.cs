using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class LocationAreas : INamedModel
    {
        public LocationAreas()
        {
            Encounters = new HashSet<Encounters>();
            LocationAreaEncounterRates = new HashSet<LocationAreaEncounterRates>();
            LocationAreaProse = new HashSet<LocationAreaProse>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int GameIndex { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<Encounters> Encounters { get; set; }
        public virtual ICollection<LocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
        public virtual ICollection<LocationAreaProse> LocationAreaProse { get; set; }
        public virtual Locations Location { get; set; }
    }
}
