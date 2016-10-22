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
                {typeof(AbilitiesController)          , "abilities"},
                {typeof(EggGroupsController)          , "egg-groups"},
                {typeof(GenerationsController)        , "generations"},
                {typeof(GrowthRatesController)        , "growth-rates"},
                {typeof(LanguagesController)          , "languages"},
                {typeof(PokedexesController)          , "pokedexes"},
                {typeof(PokemonColorsController)      , "pokemon-colors"},
                {typeof(PokemonsController)           , "pokemons"},
                {typeof(PokemonSpeciesController)     , "pokemon-species"},
                {typeof(RegionsController)            , "regions"},
                {typeof(TypesController)              , "types"},
                {typeof(VersionGroupsController)      , "version-groups"},
                {typeof(VersionsController)           , "versions"},
                {typeof(MovesController)              , "moves"},
                {typeof(EvolutionChainsController)    , "evolution-chains"},
                {typeof(LocationsController)          , "locations"},
                {typeof(PokemonShapesController)      , "pokemon-shapes"},
                {typeof(PokemonHabitatsController)    , "pokemon-habitats"},
                {typeof(PalParkAreasController)       , "pal-park-areas"},
                {typeof(PokemonFormsController)       , "pokemon-forms"},
                {typeof(MoveLearnMethodsController)   , "move-learn-methods"},
                {typeof(StatsController)              , "stats"},
                {typeof(MoveDamageClassesController)  , "move-damage-classes"},
                {typeof(CharacteristicsController)    , "characteristics"},
                {typeof(NaturesController)            , "natures"},
                {typeof(BerryFlavorsController)       , "berry-flavors"},
                {typeof(MoveBattleStylesController)   , "move-battle-styles"},
                {typeof(PokeathlonStatsController)    , "pokeathlon-stats"},
                {typeof(ContestTypesController)       , "contest-types"},
                {typeof(BerriesController)            , "berries"},
                {typeof(ItemsController)              , "items"},
                {typeof(BerryFirmnessesController)    , "berry-firmnesses"},
                {typeof(ContestEffectsController)     , "contest-effects"},
                {typeof(MoveTargetsController)        , "move-targets"},
                {typeof(SuperContestEffectsController), "super-contest-effects"},
                {typeof(MoveAilmentsController)       , "move-ailments"},
                {typeof(MoveCategoriesController)     , "move-categories"},
                {typeof(MachinesController)           , "machines"}
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