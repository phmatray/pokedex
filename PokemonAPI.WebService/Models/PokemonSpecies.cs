using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokemonSpecies : INamedModel
    {
        public PokemonSpecies()
        {
            ConquestMaxLinks = new HashSet<ConquestMaxLinks>();
            ConquestPokemonAbilities = new HashSet<ConquestPokemonAbilities>();
            ConquestPokemonStats = new HashSet<ConquestPokemonStats>();
            ConquestTransformationPokemon = new HashSet<ConquestTransformationPokemon>();
            Pokemon = new HashSet<Pokemon>();
            PokemonDexNumbers = new HashSet<PokemonDexNumbers>();
            PokemonEggGroups = new HashSet<PokemonEggGroups>();
            PokemonEvolutionEvolvedSpecies = new HashSet<PokemonEvolution>();
            PokemonEvolutionPartySpecies = new HashSet<PokemonEvolution>();
            PokemonEvolutionTradeSpecies = new HashSet<PokemonEvolution>();
            PokemonSpeciesFlavorSummaries = new HashSet<PokemonSpeciesFlavorSummaries>();
            PokemonSpeciesFlavorText = new HashSet<PokemonSpeciesFlavorText>();
            PokemonSpeciesNames = new HashSet<PokemonSpeciesNames>();
            PokemonSpeciesProse = new HashSet<PokemonSpeciesProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int? GenerationId { get; set; }
        public int? EvolvesFromSpeciesId { get; set; }
        public int? EvolutionChainId { get; set; }
        public int ColorId { get; set; }
        public int ShapeId { get; set; }
        public int? HabitatId { get; set; }
        public int GenderRate { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public bool IsBaby { get; set; }
        public int HatchCounter { get; set; }
        public bool HasGenderDifferences { get; set; }
        public int GrowthRateId { get; set; }
        public bool FormsSwitchable { get; set; }
        public int Order { get; set; }
        public int? ConquestOrder { get; set; }

        public virtual ICollection<ConquestMaxLinks> ConquestMaxLinks { get; set; }
        public virtual ICollection<ConquestPokemonAbilities> ConquestPokemonAbilities { get; set; }
        public virtual ConquestPokemonEvolution ConquestPokemonEvolution { get; set; }
        public virtual ConquestPokemonMoves ConquestPokemonMoves { get; set; }
        public virtual ICollection<ConquestPokemonStats> ConquestPokemonStats { get; set; }
        public virtual ICollection<ConquestTransformationPokemon> ConquestTransformationPokemon { get; set; }
        public virtual PalPark PalPark { get; set; }
        public virtual ICollection<Pokemon> Pokemon { get; set; }
        public virtual ICollection<PokemonDexNumbers> PokemonDexNumbers { get; set; }
        public virtual ICollection<PokemonEggGroups> PokemonEggGroups { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolutionEvolvedSpecies { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolutionPartySpecies { get; set; }
        public virtual ICollection<PokemonEvolution> PokemonEvolutionTradeSpecies { get; set; }
        public virtual ICollection<PokemonSpeciesFlavorSummaries> PokemonSpeciesFlavorSummaries { get; set; }
        public virtual ICollection<PokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public virtual ICollection<PokemonSpeciesNames> PokemonSpeciesNames { get; set; }
        public virtual ICollection<PokemonSpeciesProse> PokemonSpeciesProse { get; set; }
        public virtual PokemonColors Color { get; set; }
        public virtual EvolutionChains EvolutionChain { get; set; }
        public virtual PokemonSpecies EvolvesFromSpecies { get; set; }
        public virtual ICollection<PokemonSpecies> InverseEvolvesFromSpecies { get; set; }
        public virtual Generations Generation { get; set; }
        public virtual GrowthRates GrowthRate { get; set; }
        public virtual PokemonHabitats Habitat { get; set; }
        public virtual PokemonShapes Shape { get; set; }
    }
}
