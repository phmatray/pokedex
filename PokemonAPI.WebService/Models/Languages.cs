using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFLanguages : IEFModel, IEFIdentifier
    {
        public EFLanguages()
        {
            AbilityChangelogProse = new HashSet<EFAbilityChangelogProse>();
            AbilityFlavorText = new HashSet<EFAbilityFlavorText>();
            AbilityNames = new HashSet<EFAbilityNames>();
            AbilityProse = new HashSet<EFAbilityProse>();
            BerryFirmnessNames = new HashSet<EFBerryFirmnessNames>();
            CharacteristicText = new HashSet<EFCharacteristicText>();
            ConquestEpisodeNames = new HashSet<EFConquestEpisodeNames>();
            ConquestKingdomNames = new HashSet<EFConquestKingdomNames>();
            ConquestMoveDisplacementProse = new HashSet<EFConquestMoveDisplacementProse>();
            ConquestMoveEffectProse = new HashSet<EFConquestMoveEffectProse>();
            ConquestMoveRangeProse = new HashSet<EFConquestMoveRangeProse>();
            ConquestStatNames = new HashSet<EFConquestStatNames>();
            ConquestWarriorNames = new HashSet<EFConquestWarriorNames>();
            ConquestWarriorSkillNames = new HashSet<EFConquestWarriorSkillNames>();
            ConquestWarriorStatNames = new HashSet<EFConquestWarriorStatNames>();
            ContestEffectProse = new HashSet<EFContestEffectProse>();
            ContestTypeNames = new HashSet<EFContestTypeNames>();
            EggGroupProse = new HashSet<EFEggGroupProse>();
            EncounterConditionProse = new HashSet<EFEncounterConditionProse>();
            EncounterConditionValueProse = new HashSet<EFEncounterConditionValueProse>();
            EncounterMethodProse = new HashSet<EFEncounterMethodProse>();
            EvolutionTriggerProse = new HashSet<EFEvolutionTriggerProse>();
            GenerationNames = new HashSet<EFGenerationNames>();
            GrowthRateProse = new HashSet<EFGrowthRateProse>();
            ItemCategoryProse = new HashSet<EFItemCategoryProse>();
            ItemFlagProse = new HashSet<EFItemFlagProse>();
            ItemFlavorSummaries = new HashSet<EFItemFlavorSummaries>();
            ItemFlavorText = new HashSet<EFItemFlavorText>();
            ItemFlingEffectProse = new HashSet<EFItemFlingEffectProse>();
            ItemNames = new HashSet<EFItemNames>();
            ItemPocketNames = new HashSet<EFItemPocketNames>();
            ItemProse = new HashSet<EFItemProse>();
            LanguageNamesLanguage = new HashSet<EFLanguageNames>();
            LanguageNamesLocalLanguage = new HashSet<EFLanguageNames>();
            LocationAreaProse = new HashSet<EFLocationAreaProse>();
            LocationNames = new HashSet<EFLocationNames>();
            MoveBattleStyleProse = new HashSet<EFMoveBattleStyleProse>();
            MoveDamageClassProse = new HashSet<EFMoveDamageClassProse>();
            MoveEffectChangelogProse = new HashSet<EFMoveEffectChangelogProse>();
            MoveEffectProse = new HashSet<EFMoveEffectProse>();
            MoveFlagProse = new HashSet<EFMoveFlagProse>();
            MoveFlavorSummaries = new HashSet<EFMoveFlavorSummaries>();
            MoveFlavorText = new HashSet<EFMoveFlavorText>();
            MoveMetaAilmentNames = new HashSet<EFMoveMetaAilmentNames>();
            MoveMetaCategoryProse = new HashSet<EFMoveMetaCategoryProse>();
            MoveNames = new HashSet<EFMoveNames>();
            MoveTargetProse = new HashSet<EFMoveTargetProse>();
            NatureNames = new HashSet<EFNatureNames>();
            PalParkAreaNames = new HashSet<EFPalParkAreaNames>();
            PokeathlonStatNames = new HashSet<EFPokeathlonStatNames>();
            PokedexProse = new HashSet<EFPokedexProse>();
            PokemonColorNames = new HashSet<EFPokemonColorNames>();
            PokemonFormNames = new HashSet<EFPokemonFormNames>();
            PokemonHabitatNames = new HashSet<EFPokemonHabitatNames>();
            PokemonMoveMethodProse = new HashSet<EFPokemonMoveMethodProse>();
            PokemonShapeProse = new HashSet<EFPokemonShapeProse>();
            PokemonSpeciesFlavorSummaries = new HashSet<EFPokemonSpeciesFlavorSummaries>();
            PokemonSpeciesFlavorText = new HashSet<EFPokemonSpeciesFlavorText>();
            PokemonSpeciesNames = new HashSet<EFPokemonSpeciesNames>();
            PokemonSpeciesProse = new HashSet<EFPokemonSpeciesProse>();
            RegionNames = new HashSet<EFRegionNames>();
            StatNames = new HashSet<EFStatNames>();
            SuperContestEffectProse = new HashSet<EFSuperContestEffectProse>();
            TypeNames = new HashSet<EFTypeNames>();
            VersionNames = new HashSet<EFVersionNames>();
        }

        public int Id { get; set; }
        public string Iso639 { get; set; }
        public string Iso3166 { get; set; }
        public string Identifier { get; set; }
        public bool Official { get; set; }
        public int? Order { get; set; }

        public virtual ICollection<EFAbilityChangelogProse> AbilityChangelogProse { get; set; }
        public virtual ICollection<EFAbilityFlavorText> AbilityFlavorText { get; set; }
        public virtual ICollection<EFAbilityNames> AbilityNames { get; set; }
        public virtual ICollection<EFAbilityProse> AbilityProse { get; set; }
        public virtual ICollection<EFBerryFirmnessNames> BerryFirmnessNames { get; set; }
        public virtual ICollection<EFCharacteristicText> CharacteristicText { get; set; }
        public virtual ICollection<EFConquestEpisodeNames> ConquestEpisodeNames { get; set; }
        public virtual ICollection<EFConquestKingdomNames> ConquestKingdomNames { get; set; }
        public virtual ICollection<EFConquestMoveDisplacementProse> ConquestMoveDisplacementProse { get; set; }
        public virtual ICollection<EFConquestMoveEffectProse> ConquestMoveEffectProse { get; set; }
        public virtual ICollection<EFConquestMoveRangeProse> ConquestMoveRangeProse { get; set; }
        public virtual ICollection<EFConquestStatNames> ConquestStatNames { get; set; }
        public virtual ICollection<EFConquestWarriorNames> ConquestWarriorNames { get; set; }
        public virtual ICollection<EFConquestWarriorSkillNames> ConquestWarriorSkillNames { get; set; }
        public virtual ICollection<EFConquestWarriorStatNames> ConquestWarriorStatNames { get; set; }
        public virtual ICollection<EFContestEffectProse> ContestEffectProse { get; set; }
        public virtual ICollection<EFContestTypeNames> ContestTypeNames { get; set; }
        public virtual ICollection<EFEggGroupProse> EggGroupProse { get; set; }
        public virtual ICollection<EFEncounterConditionProse> EncounterConditionProse { get; set; }
        public virtual ICollection<EFEncounterConditionValueProse> EncounterConditionValueProse { get; set; }
        public virtual ICollection<EFEncounterMethodProse> EncounterMethodProse { get; set; }
        public virtual ICollection<EFEvolutionTriggerProse> EvolutionTriggerProse { get; set; }
        public virtual ICollection<EFGenerationNames> GenerationNames { get; set; }
        public virtual ICollection<EFGrowthRateProse> GrowthRateProse { get; set; }
        public virtual ICollection<EFItemCategoryProse> ItemCategoryProse { get; set; }
        public virtual ICollection<EFItemFlagProse> ItemFlagProse { get; set; }
        public virtual ICollection<EFItemFlavorSummaries> ItemFlavorSummaries { get; set; }
        public virtual ICollection<EFItemFlavorText> ItemFlavorText { get; set; }
        public virtual ICollection<EFItemFlingEffectProse> ItemFlingEffectProse { get; set; }
        public virtual ICollection<EFItemNames> ItemNames { get; set; }
        public virtual ICollection<EFItemPocketNames> ItemPocketNames { get; set; }
        public virtual ICollection<EFItemProse> ItemProse { get; set; }
        public virtual ICollection<EFLanguageNames> LanguageNamesLanguage { get; set; }
        public virtual ICollection<EFLanguageNames> LanguageNamesLocalLanguage { get; set; }
        public virtual ICollection<EFLocationAreaProse> LocationAreaProse { get; set; }
        public virtual ICollection<EFLocationNames> LocationNames { get; set; }
        public virtual ICollection<EFMoveBattleStyleProse> MoveBattleStyleProse { get; set; }
        public virtual ICollection<EFMoveDamageClassProse> MoveDamageClassProse { get; set; }
        public virtual ICollection<EFMoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public virtual ICollection<EFMoveEffectProse> MoveEffectProse { get; set; }
        public virtual ICollection<EFMoveFlagProse> MoveFlagProse { get; set; }
        public virtual ICollection<EFMoveFlavorSummaries> MoveFlavorSummaries { get; set; }
        public virtual ICollection<EFMoveFlavorText> MoveFlavorText { get; set; }
        public virtual ICollection<EFMoveMetaAilmentNames> MoveMetaAilmentNames { get; set; }
        public virtual ICollection<EFMoveMetaCategoryProse> MoveMetaCategoryProse { get; set; }
        public virtual ICollection<EFMoveNames> MoveNames { get; set; }
        public virtual ICollection<EFMoveTargetProse> MoveTargetProse { get; set; }
        public virtual ICollection<EFNatureNames> NatureNames { get; set; }
        public virtual ICollection<EFPalParkAreaNames> PalParkAreaNames { get; set; }
        public virtual ICollection<EFPokeathlonStatNames> PokeathlonStatNames { get; set; }
        public virtual ICollection<EFPokedexProse> PokedexProse { get; set; }
        public virtual ICollection<EFPokemonColorNames> PokemonColorNames { get; set; }
        public virtual ICollection<EFPokemonFormNames> PokemonFormNames { get; set; }
        public virtual ICollection<EFPokemonHabitatNames> PokemonHabitatNames { get; set; }
        public virtual ICollection<EFPokemonMoveMethodProse> PokemonMoveMethodProse { get; set; }
        public virtual ICollection<EFPokemonShapeProse> PokemonShapeProse { get; set; }
        public virtual ICollection<EFPokemonSpeciesFlavorSummaries> PokemonSpeciesFlavorSummaries { get; set; }
        public virtual ICollection<EFPokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public virtual ICollection<EFPokemonSpeciesNames> PokemonSpeciesNames { get; set; }
        public virtual ICollection<EFPokemonSpeciesProse> PokemonSpeciesProse { get; set; }
        public virtual ICollection<EFRegionNames> RegionNames { get; set; }
        public virtual ICollection<EFStatNames> StatNames { get; set; }
        public virtual ICollection<EFSuperContestEffectProse> SuperContestEffectProse { get; set; }
        public virtual ICollection<EFTypeNames> TypeNames { get; set; }
        public virtual ICollection<EFVersionNames> VersionNames { get; set; }
    }
}
