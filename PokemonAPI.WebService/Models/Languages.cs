using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class Languages : INamedModel
    {
        public Languages()
        {
            AbilityChangelogProse = new HashSet<AbilityChangelogProse>();
            AbilityFlavorText = new HashSet<AbilityFlavorText>();
            AbilityNames = new HashSet<AbilityNames>();
            AbilityProse = new HashSet<AbilityProse>();
            BerryFirmnessNames = new HashSet<BerryFirmnessNames>();
            CharacteristicText = new HashSet<CharacteristicText>();
            ConquestEpisodeNames = new HashSet<ConquestEpisodeNames>();
            ConquestKingdomNames = new HashSet<ConquestKingdomNames>();
            ConquestMoveDisplacementProse = new HashSet<ConquestMoveDisplacementProse>();
            ConquestMoveEffectProse = new HashSet<ConquestMoveEffectProse>();
            ConquestMoveRangeProse = new HashSet<ConquestMoveRangeProse>();
            ConquestStatNames = new HashSet<ConquestStatNames>();
            ConquestWarriorNames = new HashSet<ConquestWarriorNames>();
            ConquestWarriorSkillNames = new HashSet<ConquestWarriorSkillNames>();
            ConquestWarriorStatNames = new HashSet<ConquestWarriorStatNames>();
            ContestEffectProse = new HashSet<ContestEffectProse>();
            ContestTypeNames = new HashSet<ContestTypeNames>();
            EggGroupProse = new HashSet<EggGroupProse>();
            EncounterConditionProse = new HashSet<EncounterConditionProse>();
            EncounterConditionValueProse = new HashSet<EncounterConditionValueProse>();
            EncounterMethodProse = new HashSet<EncounterMethodProse>();
            EvolutionTriggerProse = new HashSet<EvolutionTriggerProse>();
            GenerationNames = new HashSet<GenerationNames>();
            GrowthRateProse = new HashSet<GrowthRateProse>();
            ItemCategoryProse = new HashSet<ItemCategoryProse>();
            ItemFlagProse = new HashSet<ItemFlagProse>();
            ItemFlavorSummaries = new HashSet<ItemFlavorSummaries>();
            ItemFlavorText = new HashSet<ItemFlavorText>();
            ItemFlingEffectProse = new HashSet<ItemFlingEffectProse>();
            ItemNames = new HashSet<ItemNames>();
            ItemPocketNames = new HashSet<ItemPocketNames>();
            ItemProse = new HashSet<ItemProse>();
            LanguageNamesLanguage = new HashSet<LanguageNames>();
            LanguageNamesLocalLanguage = new HashSet<LanguageNames>();
            LocationAreaProse = new HashSet<LocationAreaProse>();
            LocationNames = new HashSet<LocationNames>();
            MoveBattleStyleProse = new HashSet<MoveBattleStyleProse>();
            MoveDamageClassProse = new HashSet<MoveDamageClassProse>();
            MoveEffectChangelogProse = new HashSet<MoveEffectChangelogProse>();
            MoveEffectProse = new HashSet<MoveEffectProse>();
            MoveFlagProse = new HashSet<MoveFlagProse>();
            MoveFlavorSummaries = new HashSet<MoveFlavorSummaries>();
            MoveFlavorText = new HashSet<MoveFlavorText>();
            MoveMetaAilmentNames = new HashSet<MoveMetaAilmentNames>();
            MoveMetaCategoryProse = new HashSet<MoveMetaCategoryProse>();
            MoveNames = new HashSet<MoveNames>();
            MoveTargetProse = new HashSet<MoveTargetProse>();
            NatureNames = new HashSet<NatureNames>();
            PalParkAreaNames = new HashSet<PalParkAreaNames>();
            PokeathlonStatNames = new HashSet<PokeathlonStatNames>();
            PokedexProse = new HashSet<PokedexProse>();
            PokemonColorNames = new HashSet<PokemonColorNames>();
            PokemonFormNames = new HashSet<PokemonFormNames>();
            PokemonHabitatNames = new HashSet<PokemonHabitatNames>();
            PokemonMoveMethodProse = new HashSet<PokemonMoveMethodProse>();
            PokemonShapeProse = new HashSet<PokemonShapeProse>();
            PokemonSpeciesFlavorSummaries = new HashSet<PokemonSpeciesFlavorSummaries>();
            PokemonSpeciesFlavorText = new HashSet<PokemonSpeciesFlavorText>();
            PokemonSpeciesNames = new HashSet<PokemonSpeciesNames>();
            PokemonSpeciesProse = new HashSet<PokemonSpeciesProse>();
            RegionNames = new HashSet<RegionNames>();
            StatNames = new HashSet<StatNames>();
            SuperContestEffectProse = new HashSet<SuperContestEffectProse>();
            TypeNames = new HashSet<TypeNames>();
            VersionNames = new HashSet<VersionNames>();
        }

        public int Id { get; set; }
        public string Iso639 { get; set; }
        public string Iso3166 { get; set; }
        public string Identifier { get; set; }
        public bool Official { get; set; }
        public int? Order { get; set; }

        public virtual ICollection<AbilityChangelogProse> AbilityChangelogProse { get; set; }
        public virtual ICollection<AbilityFlavorText> AbilityFlavorText { get; set; }
        public virtual ICollection<AbilityNames> AbilityNames { get; set; }
        public virtual ICollection<AbilityProse> AbilityProse { get; set; }
        public virtual ICollection<BerryFirmnessNames> BerryFirmnessNames { get; set; }
        public virtual ICollection<CharacteristicText> CharacteristicText { get; set; }
        public virtual ICollection<ConquestEpisodeNames> ConquestEpisodeNames { get; set; }
        public virtual ICollection<ConquestKingdomNames> ConquestKingdomNames { get; set; }
        public virtual ICollection<ConquestMoveDisplacementProse> ConquestMoveDisplacementProse { get; set; }
        public virtual ICollection<ConquestMoveEffectProse> ConquestMoveEffectProse { get; set; }
        public virtual ICollection<ConquestMoveRangeProse> ConquestMoveRangeProse { get; set; }
        public virtual ICollection<ConquestStatNames> ConquestStatNames { get; set; }
        public virtual ICollection<ConquestWarriorNames> ConquestWarriorNames { get; set; }
        public virtual ICollection<ConquestWarriorSkillNames> ConquestWarriorSkillNames { get; set; }
        public virtual ICollection<ConquestWarriorStatNames> ConquestWarriorStatNames { get; set; }
        public virtual ICollection<ContestEffectProse> ContestEffectProse { get; set; }
        public virtual ICollection<ContestTypeNames> ContestTypeNames { get; set; }
        public virtual ICollection<EggGroupProse> EggGroupProse { get; set; }
        public virtual ICollection<EncounterConditionProse> EncounterConditionProse { get; set; }
        public virtual ICollection<EncounterConditionValueProse> EncounterConditionValueProse { get; set; }
        public virtual ICollection<EncounterMethodProse> EncounterMethodProse { get; set; }
        public virtual ICollection<EvolutionTriggerProse> EvolutionTriggerProse { get; set; }
        public virtual ICollection<GenerationNames> GenerationNames { get; set; }
        public virtual ICollection<GrowthRateProse> GrowthRateProse { get; set; }
        public virtual ICollection<ItemCategoryProse> ItemCategoryProse { get; set; }
        public virtual ICollection<ItemFlagProse> ItemFlagProse { get; set; }
        public virtual ICollection<ItemFlavorSummaries> ItemFlavorSummaries { get; set; }
        public virtual ICollection<ItemFlavorText> ItemFlavorText { get; set; }
        public virtual ICollection<ItemFlingEffectProse> ItemFlingEffectProse { get; set; }
        public virtual ICollection<ItemNames> ItemNames { get; set; }
        public virtual ICollection<ItemPocketNames> ItemPocketNames { get; set; }
        public virtual ICollection<ItemProse> ItemProse { get; set; }
        public virtual ICollection<LanguageNames> LanguageNamesLanguage { get; set; }
        public virtual ICollection<LanguageNames> LanguageNamesLocalLanguage { get; set; }
        public virtual ICollection<LocationAreaProse> LocationAreaProse { get; set; }
        public virtual ICollection<LocationNames> LocationNames { get; set; }
        public virtual ICollection<MoveBattleStyleProse> MoveBattleStyleProse { get; set; }
        public virtual ICollection<MoveDamageClassProse> MoveDamageClassProse { get; set; }
        public virtual ICollection<MoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public virtual ICollection<MoveEffectProse> MoveEffectProse { get; set; }
        public virtual ICollection<MoveFlagProse> MoveFlagProse { get; set; }
        public virtual ICollection<MoveFlavorSummaries> MoveFlavorSummaries { get; set; }
        public virtual ICollection<MoveFlavorText> MoveFlavorText { get; set; }
        public virtual ICollection<MoveMetaAilmentNames> MoveMetaAilmentNames { get; set; }
        public virtual ICollection<MoveMetaCategoryProse> MoveMetaCategoryProse { get; set; }
        public virtual ICollection<MoveNames> MoveNames { get; set; }
        public virtual ICollection<MoveTargetProse> MoveTargetProse { get; set; }
        public virtual ICollection<NatureNames> NatureNames { get; set; }
        public virtual ICollection<PalParkAreaNames> PalParkAreaNames { get; set; }
        public virtual ICollection<PokeathlonStatNames> PokeathlonStatNames { get; set; }
        public virtual ICollection<PokedexProse> PokedexProse { get; set; }
        public virtual ICollection<PokemonColorNames> PokemonColorNames { get; set; }
        public virtual ICollection<PokemonFormNames> PokemonFormNames { get; set; }
        public virtual ICollection<PokemonHabitatNames> PokemonHabitatNames { get; set; }
        public virtual ICollection<PokemonMoveMethodProse> PokemonMoveMethodProse { get; set; }
        public virtual ICollection<PokemonShapeProse> PokemonShapeProse { get; set; }
        public virtual ICollection<PokemonSpeciesFlavorSummaries> PokemonSpeciesFlavorSummaries { get; set; }
        public virtual ICollection<PokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public virtual ICollection<PokemonSpeciesNames> PokemonSpeciesNames { get; set; }
        public virtual ICollection<PokemonSpeciesProse> PokemonSpeciesProse { get; set; }
        public virtual ICollection<RegionNames> RegionNames { get; set; }
        public virtual ICollection<StatNames> StatNames { get; set; }
        public virtual ICollection<SuperContestEffectProse> SuperContestEffectProse { get; set; }
        public virtual ICollection<TypeNames> TypeNames { get; set; }
        public virtual ICollection<VersionNames> VersionNames { get; set; }
    }
}
