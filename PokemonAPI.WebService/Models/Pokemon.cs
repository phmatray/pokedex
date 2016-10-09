using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Pokemon : INamedModel
    {
        public Pokemon()
        {
            Encounters = new HashSet<Encounters>();
            PokemonAbilities = new HashSet<PokemonAbilities>();
            PokemonForms = new HashSet<PokemonForms>();
            PokemonGameIndices = new HashSet<PokemonGameIndices>();
            PokemonItems = new HashSet<PokemonItems>();
            PokemonMoves = new HashSet<PokemonMoves>();
            PokemonStats = new HashSet<PokemonStats>();
            PokemonTypes = new HashSet<PokemonTypes>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int? SpeciesId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public int Order { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<Encounters> Encounters { get; set; }
        public virtual ICollection<PokemonAbilities> PokemonAbilities { get; set; }
        public virtual ICollection<PokemonForms> PokemonForms { get; set; }
        public virtual ICollection<PokemonGameIndices> PokemonGameIndices { get; set; }
        public virtual ICollection<PokemonItems> PokemonItems { get; set; }
        public virtual ICollection<PokemonMoves> PokemonMoves { get; set; }
        public virtual ICollection<PokemonStats> PokemonStats { get; set; }
        public virtual ICollection<PokemonTypes> PokemonTypes { get; set; }
        public virtual PokemonSpecies Species { get; set; }
    }
}
