using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Versions : INamedModel
    {
        public Versions()
        {
            Encounters = new HashSet<Encounters>();
            LocationAreaEncounterRates = new HashSet<LocationAreaEncounterRates>();
            PokemonGameIndices = new HashSet<PokemonGameIndices>();
            PokemonItems = new HashSet<PokemonItems>();
            PokemonSpeciesFlavorText = new HashSet<PokemonSpeciesFlavorText>();
            VersionNames = new HashSet<VersionNames>();
        }

        public int Id { get; set; }
        public int VersionGroupId { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<Encounters> Encounters { get; set; }
        public virtual ICollection<LocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
        public virtual ICollection<PokemonGameIndices> PokemonGameIndices { get; set; }
        public virtual ICollection<PokemonItems> PokemonItems { get; set; }
        public virtual ICollection<PokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public virtual ICollection<VersionNames> VersionNames { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
