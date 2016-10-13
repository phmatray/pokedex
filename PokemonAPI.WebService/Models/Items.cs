using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFItems : IEFModel, IEFIdentifier
    {
        public EFItems()
        {
            Berries = new HashSet<EFBerries>();
            ConquestPokemonEvolution = new HashSet<EFConquestPokemonEvolution>();
            EvolutionChains = new HashSet<EFEvolutionChains>();
            ItemFlagMap = new HashSet<EFItemFlagMap>();
            ItemFlavorSummaries = new HashSet<EFItemFlavorSummaries>();
            ItemFlavorText = new HashSet<EFItemFlavorText>();
            ItemGameIndices = new HashSet<EFItemGameIndices>();
            ItemNames = new HashSet<EFItemNames>();
            ItemProse = new HashSet<EFItemProse>();
            Machines = new HashSet<EFMachines>();
            PokemonEvolutionHeldItem = new HashSet<EFPokemonEvolution>();
            PokemonEvolutionTriggerItem = new HashSet<EFPokemonEvolution>();
            PokemonItems = new HashSet<EFPokemonItems>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int CategoryId { get; set; }
        public int Cost { get; set; }
        public int? FlingPower { get; set; }
        public int? FlingEffectId { get; set; }

        public virtual ICollection<EFBerries> Berries { get; set; }
        public virtual ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual ICollection<EFEvolutionChains> EvolutionChains { get; set; }
        public virtual ICollection<EFItemFlagMap> ItemFlagMap { get; set; }
        public virtual ICollection<EFItemFlavorSummaries> ItemFlavorSummaries { get; set; }
        public virtual ICollection<EFItemFlavorText> ItemFlavorText { get; set; }
        public virtual ICollection<EFItemGameIndices> ItemGameIndices { get; set; }
        public virtual ICollection<EFItemNames> ItemNames { get; set; }
        public virtual ICollection<EFItemProse> ItemProse { get; set; }
        public virtual ICollection<EFMachines> Machines { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolutionHeldItem { get; set; }
        public virtual ICollection<EFPokemonEvolution> PokemonEvolutionTriggerItem { get; set; }
        public virtual ICollection<EFPokemonItems> PokemonItems { get; set; }
        public virtual EFItemCategories Category { get; set; }
        public virtual EFItemFlingEffects FlingEffect { get; set; }
    }
}
