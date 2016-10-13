using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFVersions : IEFModel, IEFIdentifier
    {
        public EFVersions()
        {
            Encounters = new HashSet<EFEncounters>();
            LocationAreaEncounterRates = new HashSet<EFLocationAreaEncounterRates>();
            PokemonGameIndices = new HashSet<EFPokemonGameIndices>();
            PokemonItems = new HashSet<EFPokemonItems>();
            PokemonSpeciesFlavorText = new HashSet<EFPokemonSpeciesFlavorText>();
            VersionNames = new HashSet<EFVersionNames>();
        }

        public int Id { get; set; }
        public int VersionGroupId { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFEncounters> Encounters { get; set; }
        public virtual ICollection<EFLocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
        public virtual ICollection<EFPokemonGameIndices> PokemonGameIndices { get; set; }
        public virtual ICollection<EFPokemonItems> PokemonItems { get; set; }
        public virtual ICollection<EFPokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public virtual ICollection<EFVersionNames> VersionNames { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
