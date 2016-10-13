using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokemon : IEFModel, IEFIdentifier
    {
        public EFPokemon()
        {
            Encounters = new HashSet<EFEncounters>();
            PokemonAbilities = new HashSet<EFPokemonAbilities>();
            PokemonForms = new HashSet<EFPokemonForms>();
            PokemonGameIndices = new HashSet<EFPokemonGameIndices>();
            PokemonItems = new HashSet<EFPokemonItems>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            PokemonStats = new HashSet<EFPokemonStats>();
            PokemonTypes = new HashSet<EFPokemonTypes>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int? SpeciesId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public int Order { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<EFEncounters> Encounters { get; set; }
        public virtual ICollection<EFPokemonAbilities> PokemonAbilities { get; set; }
        public virtual ICollection<EFPokemonForms> PokemonForms { get; set; }
        public virtual ICollection<EFPokemonGameIndices> PokemonGameIndices { get; set; }
        public virtual ICollection<EFPokemonItems> PokemonItems { get; set; }
        public virtual ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public virtual ICollection<EFPokemonStats> PokemonStats { get; set; }
        public virtual ICollection<EFPokemonTypes> PokemonTypes { get; set; }
        public virtual EFPokemonSpecies Species { get; set; }
    }
}
