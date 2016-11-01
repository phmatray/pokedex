//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Reflection.PortableExecutable;
//using System.Threading.Tasks;
//using Microsoft.CodeAnalysis;
//using PokemonAPI.WebService.Models;
//using Microsoft.EntityFrameworkCore;
//using PokemonAPI.Models.Rsc;

//namespace PokemonAPI.WebService.Wip
//{
//    public class Test
//    {
//        private readonly Referentials _referentials;

//        public Test(Referentials referentials)
//        {
//            _referentials = referentials;
//            _referentials.Languages.Where(
//        }
//    }


//    public class Referentials
//    {
//        private readonly VeekunContext _context;

//        public Referentials(VeekunContext _context)
//        {
//            this._context = _context;
//            IsReady = false;

//            FetchData();
//        }

//        private async Task FetchData()
//        {
//            //_context.GetType().GetProperties(BindingFlags.Public|)

//            Abilities = await _context.Abilities.Select(x => x.ToAbility()).ToListAsync();
//            Languages = await _context.Languages.Select(x => x.ToLanguage()).ToListAsync();
//            Pokemon = await _context.Pokemon.

//            IsReady = true;
//        }


//        public static bool IsReady { get; private set; }














//        public List<Ability> Abilities { get; private set; }
//        public List<AbilityChangelog> AbilityChangelog { get; private set; }
//        public List<AbilityChangelogProse> AbilityChangelogProse { get; private set; }
//        public List<AbilityFlavorText> AbilityFlavorText { get; private set; }
//        public List<AbilityName> AbilityNames { get; private set; }
//        public List<AbilityProse> AbilityProse { get; private set; }
//        public List<Berry> Berries { get; private set; }
//        public List<BerryFirmnes> BerryFirmness { get; private set; }
//        public List<BerryFirmnessName> BerryFirmnessNames { get; private set; }
//        public List<BerryFlavor> BerryFlavors { get; private set; }
//        public List<CharacteristicText> CharacteristicText { get; private set; }
//        public List<Characteristic> Characteristics { get; private set; }
//        public List<ContestCombo> ContestCombos { get; private set; }
//        public List<ContestEffectProse> ContestEffectProse { get; private set; }
//        public List<ContestEffect> ContestEffects { get; private set; }
//        public List<ContestTypeName> ContestTypeNames { get; private set; }
//        public List<ContestType> ContestTypes { get; private set; }
//        public List<EggGroupProse> EggGroupProse { get; private set; }
//        public List<EggGroup> EggGroups { get; private set; }
//        public List<EncounterConditionProse> EncounterConditionProse { get; private set; }
//        public List<EncounterConditionValueMap> EncounterConditionValueMap { get; private set; }
//        public List<EncounterConditionValueProse> EncounterConditionValueProse { get; private set; }
//        public List<EncounterConditionValue> EncounterConditionValues { get; private set; }
//        public List<EncounterCondition> EncounterConditions { get; private set; }
//        public List<EncounterMethodProse> EncounterMethodProse { get; private set; }
//        public List<EncounterMethod> EncounterMethods { get; private set; }
//        public List<EncounterSlot> EncounterSlots { get; private set; }
//        public List<Encounter> Encounters { get; private set; }
//        public List<EvolutionChain> EvolutionChains { get; private set; }
//        public List<EvolutionTriggerProse> EvolutionTriggerProse { get; private set; }
//        public List<EvolutionTrigger> EvolutionTriggers { get; private set; }
//        public List<Experience> Experience { get; private set; }
//        public List<Gender> Genders { get; private set; }
//        public List<GenerationName> GenerationNames { get; private set; }
//        public List<Generation> Generations { get; private set; }
//        public List<GrowthRateProse> GrowthRateProse { get; private set; }
//        public List<GrowthRate> GrowthRates { get; private set; }
//        public List<ItemCategorie> ItemCategories { get; private set; }
//        public List<ItemCategoryProse> ItemCategoryProse { get; private set; }
//        public List<ItemFlagMap> ItemFlagMap { get; private set; }
//        public List<ItemFlagProse> ItemFlagProse { get; private set; }
//        public List<ItemFlag> ItemFlags { get; private set; }
//        public List<ItemFlavorSummarie> ItemFlavorSummaries { get; private set; }
//        public List<ItemFlavorText> ItemFlavorText { get; private set; }
//        public List<ItemFlingEffectProse> ItemFlingEffectProse { get; private set; }
//        public List<ItemFlingEffect> ItemFlingEffects { get; private set; }
//        public List<ItemGameIndice> ItemGameIndices { get; private set; }
//        public List<ItemName> ItemNames { get; private set; }
//        public List<ItemPocketName> ItemPocketNames { get; private set; }
//        public List<ItemPocket> ItemPockets { get; private set; }
//        public List<ItemProse> ItemProse { get; private set; }
//        public List<Item> Items { get; private set; }
//        public List<LanguageName> LanguageNames { get; private set; }
//        public List<Language> Languages { get; private set; }
//        public List<LocationAreaEncounterRate> LocationAreaEncounterRates { get; private set; }
//        public List<LocationAreaProse> LocationAreaProse { get; private set; }
//        public List<LocationArea> LocationAreas { get; private set; }
//        public List<LocationGameIndice> LocationGameIndices { get; private set; }
//        public List<LocationName> LocationNames { get; private set; }
//        public List<Location> Locations { get; private set; }
//        public List<Machine> Machines { get; private set; }
//        public List<MoveBattleStyleProse> MoveBattleStyleProse { get; private set; }
//        public List<MoveBattleStyle> MoveBattleStyles { get; private set; }
//        public List<MoveChangelog> MoveChangelog { get; private set; }
//        public List<MoveDamageClassProse> MoveDamageClassProse { get; private set; }
//        public List<MoveDamageClasse> MoveDamageClasses { get; private set; }
//        public List<MoveEffectChangelog> MoveEffectChangelog { get; private set; }
//        public List<MoveEffectChangelogProse> MoveEffectChangelogProse { get; private set; }
//        public List<MoveEffectProse> MoveEffectProse { get; private set; }
//        public List<MoveEffect> MoveEffects { get; private set; }
//        public List<MoveFlagMap> MoveFlagMap { get; private set; }
//        public List<MoveFlagProse> MoveFlagProse { get; private set; }
//        public List<MoveFlag> MoveFlags { get; private set; }
//        public List<MoveFlavorSummarie> MoveFlavorSummaries { get; private set; }
//        public List<MoveFlavorText> MoveFlavorText { get; private set; }
//        public List<MoveMeta> MoveMeta { get; private set; }
//        public List<MoveMetaAilmentName> MoveMetaAilmentNames { get; private set; }
//        public List<MoveMetaAilment> MoveMetaAilments { get; private set; }
//        public List<MoveMetaCategorie> MoveMetaCategories { get; private set; }
//        public List<MoveMetaCategoryProse> MoveMetaCategoryProse { get; private set; }
//        public List<MoveMetaStatChange> MoveMetaStatChanges { get; private set; }
//        public List<MoveName> MoveNames { get; private set; }
//        public List<MoveTargetProse> MoveTargetProse { get; private set; }
//        public List<MoveTarget> MoveTargets { get; private set; }
//        public List<Move> Moves { get; private set; }
//        public List<NatureBattleStylePreference> NatureBattleStylePreferences { get; private set; }
//        public List<NatureName> NatureNames { get; private set; }
//        public List<NaturePokeathlonStat> NaturePokeathlonStats { get; private set; }
//        public List<Nature> Natures { get; private set; }
//        public List<PalPark> PalPark { get; private set; }
//        public List<PalParkAreaName> PalParkAreaNames { get; private set; }
//        public List<PalParkArea> PalParkAreas { get; private set; }
//        public List<PokeathlonStatName> PokeathlonStatNames { get; private set; }
//        public List<PokeathlonStat> PokeathlonStats { get; private set; }
//        public List<PokedexProse> PokedexProse { get; private set; }
//        public List<PokedexVersionGroup> PokedexVersionGroups { get; private set; }
//        public List<Pokedexe> Pokedexes { get; private set; }
//        public List<Pokemon> Pokemon { get; private set; }
//        public List<PokemonAbilitie> PokemonAbilities { get; private set; }
//        public List<PokemonColorName> PokemonColorNames { get; private set; }
//        public List<PokemonColor> PokemonColors { get; private set; }
//        public List<PokemonDexNumber> PokemonDexNumbers { get; private set; }
//        public List<PokemonEggGroup> PokemonEggGroups { get; private set; }
//        public List<PokemonEvolution> PokemonEvolution { get; private set; }
//        public List<PokemonFormGeneration> PokemonFormGenerations { get; private set; }
//        public List<PokemonFormName> PokemonFormNames { get; private set; }
//        public List<PokemonFormPokeathlonStat> PokemonFormPokeathlonStats { get; private set; }
//        public List<PokemonForm> PokemonForms { get; private set; }
//        public List<PokemonGameIndice> PokemonGameIndices { get; private set; }
//        public List<PokemonHabitatName> PokemonHabitatNames { get; private set; }
//        public List<PokemonHabitat> PokemonHabitats { get; private set; }
//        public List<PokemonItem> PokemonItems { get; private set; }
//        public List<PokemonMoveMethodProse> PokemonMoveMethodProse { get; private set; }
//        public List<PokemonMoveMethod> PokemonMoveMethods { get; private set; }
//        public List<PokemonMove> PokemonMoves { get; private set; }
//        public List<PokemonShapeProse> PokemonShapeProse { get; private set; }
//        public List<PokemonShape> PokemonShapes { get; private set; }
//        public List<PokemonSpecie> PokemonSpecies { get; private set; }
//        public List<PokemonSpeciesFlavorSummarie> PokemonSpeciesFlavorSummaries { get; private set; }
//        public List<PokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; private set; }
//        public List<PokemonSpeciesName> PokemonSpeciesNames { get; private set; }
//        public List<PokemonSpeciesProse> PokemonSpeciesProse { get; private set; }
//        public List<PokemonStat> PokemonStats { get; private set; }
//        public List<PokemonType> PokemonTypes { get; private set; }
//        public List<RegionName> RegionNames { get; private set; }
//        public List<Region> Regions { get; private set; }
//        public List<StatName> StatNames { get; private set; }
//        public List<Stat> Stats { get; private set; }
//        public List<SuperContestCombo> SuperContestCombos { get; private set; }
//        public List<SuperContestEffectProse> SuperContestEffectProse { get; private set; }
//        public List<SuperContestEffect> SuperContestEffects { get; private set; }
//        public List<TypeEfficacy> TypeEfficacy { get; private set; }
//        public List<TypeGameIndice> TypeGameIndices { get; private set; }
//        public List<TypeName> TypeNames { get; private set; }
//        public List<Type> Types { get; private set; }
//        public List<VersionGroupPokemonMoveMethod> VersionGroupPokemonMoveMethods { get; private set; }
//        public List<VersionGroupRegion> VersionGroupRegions { get; private set; }
//        public List<VersionGroup> VersionGroups { get; private set; }
//        public List<VersionName> VersionNames { get; private set; }
//        public List<Version> Versions { get; private set; }
//    }
//}