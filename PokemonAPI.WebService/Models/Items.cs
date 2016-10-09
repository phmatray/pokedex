using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Items : INamedModel
    {
        public Items()
        {
            Berries = new HashSet<Berries>();
            ConquestPokemonEvolution = new HashSet<ConquestPokemonEvolution>();
            EvolutionChains = new HashSet<EvolutionChains>();
            ItemFlagMap = new HashSet<ItemFlagMap>();
            ItemFlavorSummaries = new HashSet<ItemFlavorSummaries>();
            ItemFlavorText = new HashSet<ItemFlavorText>();
            ItemGameIndices = new HashSet<ItemGameIndices>();
            ItemNames = new HashSet<ItemNames>();
            ItemProse = new HashSet<ItemProse>();
            Machines = new HashSet<Machines>();
            PokemonEvolutionHeldItem = new HashSet<PokemonEvolution>();
            PokemonEvolutionTriggerItem = new HashSet<PokemonEvolution>();
            PokemonItems = new HashSet<PokemonItems>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int CategoryId { get; set; }
        public int Cost { get; set; }
        public int? FlingPower { get; set; }
        public int? FlingEffectId { get; set; }

        public virtual ICollection<Berries> Berries { get; set; }
        public virtual ICollection<ConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual ICollection<EvolutionChains> EvolutionChains { get; set; }
        public virtual ICollection<ItemFlagMap> ItemFlagMap { get; set; }
        public virtual ICollection<ItemFlavorSummaries> ItemFlavorSummaries { get; set; }
        public virtual ICollection<ItemFlavorText> ItemFlavorText { get; set; }
        public virtual ICollection<ItemGameIndices> ItemGameIndices { get; set; }
        public virtual ICollection<ItemNames> ItemNames { get; set; }
        public virtual ICollection<ItemProse> ItemProse { get; set; }
        public virtual ICollection<Machines> Machines { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolutionHeldItem { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolutionTriggerItem { get; set; }
        public virtual ICollection<PokemonItems> PokemonItems { get; set; }
        public virtual ItemCategories Category { get; set; }
        public virtual ItemFlingEffects FlingEffect { get; set; }
    }
}
