using System;
using System.Collections.Generic;
using PokedexG.Uwp.Data.Models;

namespace PokedexG.Uwp.Data.Core
{
    public static class UrlHelpers
    {
        private static readonly Dictionary<Type, string> Segments;

        static UrlHelpers()
        {
            Segments = new Dictionary<Type, string>
            {
                {typeof(EFAbilities)               , "abilities"},
                {typeof(EFBerries)                 , "berries"},
                {typeof(EFBerryFirmness)           , "berry-firmnesses"},
                {typeof(EFBerryFlavors)            , "berry-flavors"},
                {typeof(EFCharacteristics)         , "characteristics"},
                {typeof(EFContestEffects)          , "contest-effects"},
                {typeof(EFContestTypes)            , "contest-types"},
                {typeof(EFEggGroups)               , "egg-groups"},
                {typeof(EFEncounterConditions)     , "encounter-conditions"},
                {typeof(EFEncounterConditionValues), "encounter-condition-values"},
                {typeof(EFEncounterMethods)        , "encounter-methods"},
                {typeof(EFEvolutionChains)         , "evolution-chains"},
                {typeof(EFEvolutionTriggers)       , "evolution-triggers"},
                {typeof(EFGenders)                 , "genders"},
                {typeof(EFGenerations)             , "generations"},
                {typeof(EFGrowthRates)             , "growth-rates"},
                {typeof(EFItemFlags)               , "item-attributes"},
                {typeof(EFItemCategories)          , "item-categories"},
                {typeof(EFItemFlingEffects)        , "item-fling-effects"},
                {typeof(EFItemPockets)             , "item-pockets"},
                {typeof(EFItems)                   , "items"},
                {typeof(EFLanguages)               , "languages"},
                {typeof(EFLocationAreas)           , "location-areas"},
                {typeof(EFLocations)               , "locations"},
                {typeof(EFMachines)                , "machines"},
                {typeof(EFMoveMetaAilments)        , "move-ailments"},
                {typeof(EFMoveBattleStyles)        , "move-battle-styles"},
                {typeof(EFMoveMetaCategories)      , "move-categories"},
                {typeof(EFMoveDamageClasses)       , "move-damage-classes"},
                {typeof(EFPokemonMoveMethods)      , "move-learn-methods"},
                {typeof(EFMoveTargets)             , "move-targets"},
                {typeof(EFMoves)                   , "moves"},
                {typeof(EFNatures)                 , "natures"},
                {typeof(EFPalParkAreas)            , "pal-park-areas"},
                {typeof(EFPokeathlonStats)         , "pokeathlon-stats"},
                {typeof(EFPokedexes)               , "pokedexes"},
                {typeof(EFPokemonColors)           , "pokemon-colors"},
                {typeof(EFPokemonForms)            , "pokemon-forms"},
                {typeof(EFPokemonHabitats)         , "pokemon-habitats"},
                {typeof(EFPokemonShapes)           , "pokemon-shapes"},
                {typeof(EFPokemonSpecies)          , "pokemon-species"},
                {typeof(EFPokemon)                 , "pokemons"},
                {typeof(EFRegions)                 , "regions"},
                {typeof(EFStats)                   , "stats"},
                {typeof(EFSuperContestEffects)     , "super-contest-effects"},
                {typeof(EFTypes)                   , "types"},
                {typeof(EFVersionGroups)           , "version-groups"},
                {typeof(EFVersions)                , "versions"}
            };
        }

        public static string RscUrl(this Type controllerType)
            => $"{Constants.SiteUrl}{Constants.BaseUrl}{Segments[controllerType]}/";

        public static string RscUrl(this Type controllerType, int id)
            => $"{controllerType.RscUrl()}{id}/";

        public static string RscUrl(this Type controllerType, string id)
            => $"{controllerType.RscUrl()}{id}/";

        public static string Previous(this Type controllerType, int limit, int offset)
            => offset - limit >= 0
                ? $"{controllerType.RscUrl().Trim('/')}?limit={limit}&offset={offset - limit}"
                : null;

        public static string Next(this Type controllerType, int limit, int offset, int count)
            => offset + limit < count
                ? $"{controllerType.RscUrl().Trim('/')}?limit={limit}&offset={offset + limit}"
                : null;
    }
}