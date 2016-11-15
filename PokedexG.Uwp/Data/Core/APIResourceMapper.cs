using PokedexG.Uwp.Data.Models;
using PokedexG.Uwp.Data.Models.Interfaces;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data.Core
{
    internal static class APIResourceMapper
    {
        #region ApiResources

        internal static APIResource ToApiResource(this EFCharacteristics src)
            => src.ToApiResource<EFCharacteristics>();

        internal static APIResource ToApiResource(this EFContestEffects src)
            => src.ToApiResource<EFContestEffects>();

        internal static APIResource ToApiResource(this EFEvolutionChains src)
            => src.ToApiResource<EFEvolutionChains>();

        internal static APIResource ToApiResource(this EFMachines src)
            => new APIResource(
                -1
            );

        internal static APIResource ToApiResource(this EFSuperContestEffects src)
            => src.ToApiResource<EFSuperContestEffects>();

        #endregion

        #region NamedApiResource

        internal static NamedAPIResource ToNamedApiResource(this EFAbilities src)
            => src.ToNamedApiResource<EFAbilities>();

        internal static NamedAPIResource ToNamedApiResource(this EFBerries src)
            => new NamedAPIResource(
                src.Id,
                src.Item.Identifier.Replace("-berry", "")
            );

        internal static NamedAPIResource ToNamedApiResource(this EFBerryFirmness src)
            => src.ToNamedApiResource<EFBerryFirmness>();

        internal static NamedAPIResource ToNamedApiResource(this EFContestTypes src)
            => src.ToNamedApiResource<EFContestTypes>();

        internal static NamedAPIResource ToNamedApiResource(this EFContestTypeNames src)
            => new NamedAPIResource(
                src.ContestTypeId,
                src.Flavor?.ToLower()
            );

        internal static NamedAPIResource ToNamedApiResource(this EFEggGroups src)
            => src.ToNamedApiResource<EFEggGroups>();

        internal static NamedAPIResource ToNamedApiResource(this EFEncounterConditions src)
            => src.ToNamedApiResource<EFEncounterConditions>();

        internal static NamedAPIResource ToNamedApiResource(this EFEncounterConditionValues src)
            => src.ToNamedApiResource<EFEncounterConditionValues>();

        internal static NamedAPIResource ToNamedApiResource(this EFEncounterMethods src)
            => src.ToNamedApiResource<EFEncounterMethods>();

        internal static NamedAPIResource ToNamedApiResource(this EFEvolutionTriggers src)
            => src.ToNamedApiResource<EFEvolutionTriggers>();

        internal static NamedAPIResource ToNamedApiResource(this EFGenders src)
            => src.ToNamedApiResource<EFGenders>();

        internal static NamedAPIResource ToNamedApiResource(this EFGenerations src)
            => src.ToNamedApiResource<EFGenerations>();

        internal static NamedAPIResource ToNamedApiResource(this EFGrowthRates src)
            => src.ToNamedApiResource<EFGrowthRates>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemFlags src)
            => src.ToNamedApiResource<EFItemFlags>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemFlingEffects src)
            => src.ToNamedApiResource<EFItemFlingEffects>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemCategories src)
            => src.ToNamedApiResource<EFItemCategories>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemPockets src)
            => src.ToNamedApiResource<EFItemPockets>();

        internal static NamedAPIResource ToNamedApiResource(this EFItems src)
            => src.ToNamedApiResource<EFItems>();

        internal static NamedAPIResource ToNamedApiResource(this EFLanguages src)
            => src.ToNamedApiResource<EFLanguages>();

        internal static NamedAPIResource ToNamedApiResource(this EFLocationAreas src)
            => src.Location == null
                ? src.ToNamedApiResource<EFLocationAreas>()
                : new NamedAPIResource(
                    src.Id,
                    $"{src.Location.Identifier}-{src.Identifier ?? "area"}"
                );

        internal static NamedAPIResource ToNamedApiResource(this EFLocations src)
            => src.ToNamedApiResource<EFLocations>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveMetaAilments src)
            => src.ToNamedApiResource<EFMoveMetaAilments>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveBattleStyles src)
            => src.ToNamedApiResource<EFMoveBattleStyles>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveMetaCategories src)
            => src.ToNamedApiResource<EFMoveMetaCategories>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveDamageClasses src)
            => src.ToNamedApiResource<EFMoveDamageClasses>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonMoveMethods src)
            => src.ToNamedApiResource<EFPokemonMoveMethods>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveTargets src)
            => src.ToNamedApiResource<EFMoveTargets>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoves src)
            => src.ToNamedApiResource<EFMoves>();

        internal static NamedAPIResource ToNamedApiResource(this EFNatures src)
            => src.ToNamedApiResource<EFNatures>();

        internal static NamedAPIResource ToNamedApiResource(this EFPalParkAreas src)
            => src.ToNamedApiResource<EFPalParkAreas>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokeathlonStats src)
            => src.ToNamedApiResource<EFPokeathlonStats>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokedexes src)
            => src.ToNamedApiResource<EFPokedexes>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonColors src)
            => src.ToNamedApiResource<EFPokemonColors>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonForms src)
            => src.ToNamedApiResource<EFPokemonForms>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonHabitats src)
            => src.ToNamedApiResource<EFPokemonHabitats>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonShapes src)
            => src.ToNamedApiResource<EFPokemonShapes>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonSpecies src)
            => src.ToNamedApiResource<EFPokemonSpecies>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemon src)
            => src.ToNamedApiResource<EFPokemon>();

        internal static NamedAPIResource ToNamedApiResource(this EFRegions src)
            => src.ToNamedApiResource<EFRegions>();

        internal static NamedAPIResource ToNamedApiResource(this EFStats src)
            => src.ToNamedApiResource<EFStats>();

        internal static NamedAPIResource ToNamedApiResource(this EFTypes src)
            => src.ToNamedApiResource<EFTypes>();

        internal static NamedAPIResource ToNamedApiResource(this EFVersionGroups src)
            => src.ToNamedApiResource<EFVersionGroups>();

        internal static NamedAPIResource ToNamedApiResource(this EFVersions src)
            => src.ToNamedApiResource<EFVersions>();

        #endregion

        #region PrivateMethods

        private static APIResource ToApiResource<TModel>(this IEFId id)
            => new APIResource(id.Id);

        private static NamedAPIResource ToNamedApiResource<TModel>(this IEFIdentifier identifier)
            => new NamedAPIResource(identifier.Id, identifier.Identifier);

        #endregion
    }
}