using System;
using System.Collections.Generic;
using PokemonAPI.WebService.Controllers;
using PokemonAPI.WebService.Controllers.Base;

namespace PokemonAPI.WebService.Core
{
    // appel: typeof(GenerationsController).RegisterSegment("generations");
    public static class UrlSegments
    {
        private static readonly Dictionary<Type, string> Segments;

        static UrlSegments()
        {
            Segments = new Dictionary<Type, string>
            {
                {typeof(AbilitiesController)               , "abilities"},
                {typeof(BerriesController)                 , "berries"},
                {typeof(BerryFirmnessesController)         , "berry-firmnesses"},
                {typeof(BerryFlavorsController)            , "berry-flavors"},
                {typeof(CharacteristicsController)         , "characteristics"},
                {typeof(ContestEffectsController)          , "contest-effects"},
                {typeof(ContestTypesController)            , "contest-types"},
                {typeof(EggGroupsController)               , "egg-groups"},
                {typeof(EncounterConditionValuesController), "encounter-condition-values"},
                {typeof(EncounterMethodsController)        , "encounter-methods"},
                {typeof(EvolutionChainsController)         , "evolution-chains"},
                {typeof(EvolutionTriggersController)       , "evolution-triggers"},
                {typeof(GendersController)                 , "genders"},
                {typeof(GenerationsController)             , "generations"},
                {typeof(GrowthRatesController)             , "growth-rates"},
                {typeof(ItemAttributesController)          , "item-attributes"},
                {typeof(ItemCategoriesController)          , "item-categories"},
                {typeof(ItemFlingEffectsController)        , "item-fling-effects"},
                {typeof(ItemPocketsController)             , "item-pockets"},
                {typeof(ItemsController)                   , "items"},
                {typeof(LanguagesController)               , "languages"},
                {typeof(LocationAreasController)           , "location-areas"},
                {typeof(LocationsController)               , "locations"},
                {typeof(MachinesController)                , "machines"},
                {typeof(MoveAilmentsController)            , "move-ailments"},
                {typeof(MoveBattleStylesController)        , "move-battle-styles"},
                {typeof(MoveCategoriesController)          , "move-categories"},
                {typeof(MoveDamageClassesController)       , "move-damage-classes"},
                {typeof(MoveLearnMethodsController)        , "move-learn-methods"},
                {typeof(MoveTargetsController)             , "move-targets"},
                {typeof(MovesController)                   , "moves"},
                {typeof(NaturesController)                 , "natures"},
                {typeof(PalParkAreasController)            , "pal-park-areas"},
                {typeof(PokeathlonStatsController)         , "pokeathlon-stats"},
                {typeof(PokedexesController)               , "pokedexes"},
                {typeof(PokemonColorsController)           , "pokemon-colors"},
                {typeof(PokemonFormsController)            , "pokemon-forms"},
                {typeof(PokemonHabitatsController)         , "pokemon-habitats"},
                {typeof(PokemonShapesController)           , "pokemon-shapes"},
                {typeof(PokemonSpeciesController)          , "pokemon-species"},
                {typeof(PokemonsController)                , "pokemons"},
                {typeof(RegionsController)                 , "regions"},
                {typeof(StatsController)                   , "stats"},
                {typeof(SuperContestEffectsController)     , "super-contest-effects"},
                {typeof(TypesController)                   , "types"},
                {typeof(VersionGroupsController)           , "version-groups"},
                {typeof(VersionsController)                , "versions"},
            };
        }

        public static string RscUrl(this Type controllerType)
            => $"{Constants.SiteUrl}{Constants.BaseUrl}{controllerType.Segment()}/";

        public static string RscUrl(this Type controllerType, int id)
            => $"{controllerType.RscUrl()}{id}/";

        public static string Segment(this ApiController controller)
            => Segments[controller.GetType()];

        public static string Segment(this Type controllerType)
            => Segments[controllerType];
    }
}