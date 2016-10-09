using SQLite.Net.Attributes;

namespace PokedexG.Uwp.Services.VeekunServices.Models
{
    [Table("conquest_move_effects")]
    public class ConquestMoveEffectsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }
    }

    [Table("move_meta_categories")]
    public class MoveMetaCategoriesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("pokemon_shapes")]
    public class PokemonShapesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("languages")]
    public class LanguagesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("iso639")]
        public string Iso639 { get; set; }

        [Column("iso3166")]
        public string Iso3166 { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("official")]
        public bool Official { get; set; }

        [Column("order")]
        public int? Order { get; set; }
    }

    [Table("conquest_move_displacements")]
    public class ConquestMoveDisplacementsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("affects_target")]
        public bool AffectsTarget { get; set; }
    }

    [Table("berry_firmness")]
    public class BerryFirmnessRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("pokemon_move_methods")]
    public class PokemonMoveMethodsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("conquest_episodes")]
    public class ConquestEpisodesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("move_battle_styles")]
    public class MoveBattleStylesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("egg_groups")]
    public class EggGroupsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("encounter_conditions")]
    public class EncounterConditionsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("conquest_warrior_skills")]
    public class ConquestWarriorSkillsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("item_flags")]
    public class ItemFlagsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("item_pockets")]
    public class ItemPocketsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("contest_types")]
    public class ContestTypesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("conquest_warrior_archetypes")]
    public class ConquestWarriorArchetypesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("evolution_triggers")]
    public class EvolutionTriggersRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("move_effects")]
    public class MoveEffectsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }
    }

    [Table("conquest_warrior_stats")]
    public class ConquestWarriorStatsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("conquest_stats")]
    public class ConquestStatsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("is_base")]
        public bool IsBase { get; set; }
    }

    [Table("encounter_methods")]
    public class EncounterMethodsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("order")]
        public int Order { get; set; }
    }

    [Table("pokemon_colors")]
    public class PokemonColorsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("move_damage_classes")]
    public class MoveDamageClassesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("pal_park_areas")]
    public class PalParkAreasRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("move_targets")]
    public class MoveTargetsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("growth_rates")]
    public class GrowthRatesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("formula")]
        public string Formula { get; set; }
    }

    [Table("contest_effects")]
    public class ContestEffectsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("appeal")]
        public short Appeal { get; set; }

        [Column("jam")]
        public short Jam { get; set; }
    }

    [Table("move_meta_ailments")]
    public class MoveMetaAilmentsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("move_flags")]
    public class MoveFlagsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("genders")]
    public class GendersRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("pokeathlon_stats")]
    public class PokeathlonStatsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("pokemon_habitats")]
    public class PokemonHabitatsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("regions")]
    public class RegionsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("super_contest_effects")]
    public class SuperContestEffectsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("appeal")]
        public short Appeal { get; set; }
    }

    [Table("conquest_move_ranges")]
    public class ConquestMoveRangesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("targets")]
        public int Targets { get; set; }
    }

    [Table("item_fling_effects")]
    public class ItemFlingEffectsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }
    }

    [Table("move_flag_prose")]
    public class MoveFlagProseRow
    {
        [PrimaryKey]
        [Column("move_flag_id")]
        public int MoveFlagId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("pokedexes")]
    public class PokedexesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("region_id")]
        public int? RegionId { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("is_main_series")]
        public bool IsMainSeries { get; set; }
    }

    [Table("stats")]
    public class StatsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("damage_class_id")]
        public int? DamageClassId { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("is_battle_only")]
        public bool IsBattleOnly { get; set; }

        [Column("game_index")]
        public int? GameIndex { get; set; }
    }

    [Table("conquest_stat_names")]
    public class ConquestStatNamesRow
    {
        [PrimaryKey]
        [Column("conquest_stat_id")]
        public int ConquestStatId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("encounter_condition_values")]
    public class EncounterConditionValuesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("encounter_condition_id")]
        public int EncounterConditionId { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("is_default")]
        public bool IsDefault { get; set; }
    }

    [Table("move_battle_style_prose")]
    public class MoveBattleStyleProseRow
    {
        [PrimaryKey]
        [Column("move_battle_style_id")]
        public int MoveBattleStyleId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("conquest_move_effect_prose")]
    public class ConquestMoveEffectProseRow
    {
        [PrimaryKey]
        [Column("conquest_move_effect_id")]
        public int ConquestMoveEffectId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("short_effect")]
        public string ShortEffect { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("move_meta_ailment_names")]
    public class MoveMetaAilmentNamesRow
    {
        [PrimaryKey]
        [Column("move_meta_ailment_id")]
        public int MoveMetaAilmentId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("move_damage_class_prose")]
    public class MoveDamageClassProseRow
    {
        [PrimaryKey]
        [Column("move_damage_class_id")]
        public int MoveDamageClassId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("generations")]
    public class GenerationsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("main_region_id")]
        public int MainRegionId { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("region_names")]
    public class RegionNamesRow
    {
        [PrimaryKey]
        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("growth_rate_prose")]
    public class GrowthRateProseRow
    {
        [PrimaryKey]
        [Column("growth_rate_id")]
        public int GrowthRateId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("conquest_warrior_stat_names")]
    public class ConquestWarriorStatNamesRow
    {
        [PrimaryKey]
        [Column("warrior_stat_id")]
        public int WarriorStatId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("pokemon_move_method_prose")]
    public class PokemonMoveMethodProseRow
    {
        [PrimaryKey]
        [Column("pokemon_move_method_id")]
        public int PokemonMoveMethodId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("conquest_episode_names")]
    public class ConquestEpisodeNamesRow
    {
        [PrimaryKey]
        [Column("episode_id")]
        public int EpisodeId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("pal_park_area_names")]
    public class PalParkAreaNamesRow
    {
        [PrimaryKey]
        [Column("pal_park_area_id")]
        public int PalParkAreaId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("encounter_condition_prose")]
    public class EncounterConditionProseRow
    {
        [PrimaryKey]
        [Column("encounter_condition_id")]
        public int EncounterConditionId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("conquest_warrior_skill_names")]
    public class ConquestWarriorSkillNamesRow
    {
        [PrimaryKey]
        [Column("skill_id")]
        public int SkillId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("experience")]
    public class ExperienceRow
    {
        [PrimaryKey]
        [Column("growth_rate_id")]
        public int GrowthRateId { get; set; }

        [Column("level")]
        public int Level { get; set; }

        [Column("experience")]
        public int Experience { get; set; }
    }

    [Table("conquest_warriors")]
    public class ConquestWarriorsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("gender_id")]
        public int GenderId { get; set; }

        [Column("archetype_id")]
        public int? ArchetypeId { get; set; }
    }

    [Table("move_meta_category_prose")]
    public class MoveMetaCategoryProseRow
    {
        [PrimaryKey]
        [Column("move_meta_category_id")]
        public int MoveMetaCategoryId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("contest_type_names")]
    public class ContestTypeNamesRow
    {
        [PrimaryKey]
        [Column("contest_type_id")]
        public int ContestTypeId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("flavor")]
        public string Flavor { get; set; }

        [Column("color")]
        public string Color { get; set; }
    }

    [Table("pokemon_habitat_names")]
    public class PokemonHabitatNamesRow
    {
        [PrimaryKey]
        [Column("pokemon_habitat_id")]
        public int PokemonHabitatId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("move_target_prose")]
    public class MoveTargetProseRow
    {
        [PrimaryKey]
        [Column("move_target_id")]
        public int MoveTargetId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("conquest_move_displacement_prose")]
    public class ConquestMoveDisplacementProseRow
    {
        [PrimaryKey]
        [Column("move_displacement_id")]
        public int MoveDisplacementId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("short_effect")]
        public string ShortEffect { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("item_flag_prose")]
    public class ItemFlagProseRow
    {
        [PrimaryKey]
        [Column("item_flag_id")]
        public int ItemFlagId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("evolution_trigger_prose")]
    public class EvolutionTriggerProseRow
    {
        [PrimaryKey]
        [Column("evolution_trigger_id")]
        public int EvolutionTriggerId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("berry_firmness_names")]
    public class BerryFirmnessNamesRow
    {
        [PrimaryKey]
        [Column("berry_firmness_id")]
        public int BerryFirmnessId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("item_pocket_names")]
    public class ItemPocketNamesRow
    {
        [PrimaryKey]
        [Column("item_pocket_id")]
        public int ItemPocketId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("super_contest_effect_prose")]
    public class SuperContestEffectProseRow
    {
        [PrimaryKey]
        [Column("super_contest_effect_id")]
        public int SuperContestEffectId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("flavor_text")]
        public string FlavorText { get; set; }
    }

    [Table("contest_effect_prose")]
    public class ContestEffectProseRow
    {
        [PrimaryKey]
        [Column("contest_effect_id")]
        public int ContestEffectId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("flavor_text")]
        public string FlavorText { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("egg_group_prose")]
    public class EggGroupProseRow
    {
        [PrimaryKey]
        [Column("egg_group_id")]
        public int EggGroupId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("move_effect_prose")]
    public class MoveEffectProseRow
    {
        [PrimaryKey]
        [Column("move_effect_id")]
        public int MoveEffectId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("short_effect")]
        public string ShortEffect { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("conquest_move_range_prose")]
    public class ConquestMoveRangeProseRow
    {
        [PrimaryKey]
        [Column("conquest_move_range_id")]
        public int ConquestMoveRangeId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("pokemon_shape_prose")]
    public class PokemonShapeProseRow
    {
        [PrimaryKey]
        [Column("pokemon_shape_id")]
        public int PokemonShapeId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("awesome_name")]
        public string AwesomeName { get; set; }
    }

    [Table("locations")]
    public class LocationsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("region_id")]
        public int? RegionId { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("item_fling_effect_prose")]
    public class ItemFlingEffectProseRow
    {
        [PrimaryKey]
        [Column("item_fling_effect_id")]
        public int ItemFlingEffectId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("item_categories")]
    public class ItemCategoriesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("pocket_id")]
        public int PocketId { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("encounter_method_prose")]
    public class EncounterMethodProseRow
    {
        [PrimaryKey]
        [Column("encounter_method_id")]
        public int EncounterMethodId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("pokemon_color_names")]
    public class PokemonColorNamesRow
    {
        [PrimaryKey]
        [Column("pokemon_color_id")]
        public int PokemonColorId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("pokeathlon_stat_names")]
    public class PokeathlonStatNamesRow
    {
        [PrimaryKey]
        [Column("pokeathlon_stat_id")]
        public int PokeathlonStatId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("language_names")]
    public class LanguageNamesRow
    {
        [PrimaryKey]
        [Column("language_id")]
        public int LanguageId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("abilities")]
    public class AbilitiesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("is_main_series")]
        public bool IsMainSeries { get; set; }
    }

    [Table("location_areas")]
    public class LocationAreasRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("location_id")]
        public int LocationId { get; set; }

        [Column("game_index")]
        public int GameIndex { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("stat_names")]
    public class StatNamesRow
    {
        [PrimaryKey]
        [Column("stat_id")]
        public int StatId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("location_game_indices")]
    public class LocationGameIndicesRow
    {
        [PrimaryKey]
        [Column("location_id")]
        public int LocationId { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("game_index")]
        public int GameIndex { get; set; }
    }

    [Table("item_category_prose")]
    public class ItemCategoryProseRow
    {
        [PrimaryKey]
        [Column("item_category_id")]
        public int ItemCategoryId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("encounter_condition_value_prose")]
    public class EncounterConditionValueProseRow
    {
        [PrimaryKey]
        [Column("encounter_condition_value_id")]
        public int EncounterConditionValueId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("conquest_warrior_names")]
    public class ConquestWarriorNamesRow
    {
        [PrimaryKey]
        [Column("warrior_id")]
        public int WarriorId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("items")]
    public class ItemsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("cost")]
        public int Cost { get; set; }

        [Column("fling_power")]
        public int? FlingPower { get; set; }

        [Column("fling_effect_id")]
        public int? FlingEffectId { get; set; }
    }

    [Table("generation_names")]
    public class GenerationNamesRow
    {
        [PrimaryKey]
        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("types")]
    public class TypesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("damage_class_id")]
        public int? DamageClassId { get; set; }
    }

    [Table("location_names")]
    public class LocationNamesRow
    {
        [PrimaryKey]
        [Column("location_id")]
        public int LocationId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("characteristics")]
    public class CharacteristicsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("stat_id")]
        public int StatId { get; set; }

        [Column("gene_mod_5")]
        public int GeneMod5 { get; set; }
    }

    [Table("conquest_episode_warriors")]
    public class ConquestEpisodeWarriorsRow
    {
        [PrimaryKey]
        [Column("episode_id")]
        public int EpisodeId { get; set; }

        [Column("warrior_id")]
        public int WarriorId { get; set; }
    }

    [Table("conquest_warrior_ranks")]
    public class ConquestWarriorRanksRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("warrior_id")]
        public int WarriorId { get; set; }

        [Column("rank")]
        public int Rank { get; set; }

        [Column("skill_id")]
        public int SkillId { get; set; }
    }

    [Table("version_groups")]
    public class VersionGroupsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("order")]
        public int? Order { get; set; }
    }

    [Table("natures")]
    public class NaturesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("decreased_stat_id")]
        public int DecreasedStatId { get; set; }

        [Column("increased_stat_id")]
        public int IncreasedStatId { get; set; }

        [Column("hates_flavor_id")]
        public int HatesFlavorId { get; set; }

        [Column("likes_flavor_id")]
        public int LikesFlavorId { get; set; }

        [Column("game_index")]
        public int GameIndex { get; set; }
    }

    [Table("pokedex_prose")]
    public class PokedexProseRow
    {
        [PrimaryKey]
        [Column("pokedex_id")]
        public int PokedexId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }

    [Table("type_efficacy")]
    public class TypeEfficacyRow
    {
        [PrimaryKey]
        [Column("damage_type_id")]
        public int DamageTypeId { get; set; }

        [Column("target_type_id")]
        public int TargetTypeId { get; set; }

        [Column("damage_factor")]
        public int DamageFactor { get; set; }
    }

    [Table("location_area_prose")]
    public class LocationAreaProseRow
    {
        [PrimaryKey]
        [Column("location_area_id")]
        public int LocationAreaId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("ability_names")]
    public class AbilityNamesRow
    {
        [PrimaryKey]
        [Column("ability_id")]
        public int AbilityId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("conquest_warrior_rank_stat_map")]
    public class ConquestWarriorRankStatMapRow
    {
        [PrimaryKey]
        [Column("warrior_rank_id")]
        public int WarriorRankId { get; set; }

        [Column("warrior_stat_id")]
        public int WarriorStatId { get; set; }

        [Column("base_stat")]
        public int BaseStat { get; set; }
    }

    [Table("ability_flavor_text")]
    public class AbilityFlavorTextRow
    {
        [PrimaryKey]
        [Column("ability_id")]
        public int AbilityId { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("language_id")]
        public int LanguageId { get; set; }

        [Column("flavor_text")]
        public string FlavorText { get; set; }
    }

    [Table("ability_prose")]
    public class AbilityProseRow
    {
        [PrimaryKey]
        [Column("ability_id")]
        public int AbilityId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("short_effect")]
        public string ShortEffect { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("conquest_warrior_specialties")]
    public class ConquestWarriorSpecialtiesRow
    {
        [PrimaryKey]
        [Column("warrior_id")]
        public int WarriorId { get; set; }

        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("slot")]
        public int Slot { get; set; }
    }

    [Table("ability_changelog")]
    public class AbilityChangelogRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("ability_id")]
        public int AbilityId { get; set; }

        [Column("changed_in_version_group_id")]
        public int ChangedInVersionGroupId { get; set; }
    }

    [Table("encounter_slots")]
    public class EncounterSlotsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("encounter_method_id")]
        public int EncounterMethodId { get; set; }

        [Column("slot")]
        public int? Slot { get; set; }

        [Column("rarity")]
        public int? Rarity { get; set; }
    }

    [Table("item_names")]
    public class ItemNamesRow
    {
        [PrimaryKey]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("item_flavor_summaries")]
    public class ItemFlavorSummariesRow
    {
        [PrimaryKey]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("flavor_summary")]
        public string FlavorSummary { get; set; }
    }

    [Table("pokedex_version_groups")]
    public class PokedexVersionGroupsRow
    {
        [PrimaryKey]
        [Column("pokedex_id")]
        public int PokedexId { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }
    }

    [Table("nature_pokeathlon_stats")]
    public class NaturePokeathlonStatsRow
    {
        [PrimaryKey]
        [Column("nature_id")]
        public int NatureId { get; set; }

        [Column("pokeathlon_stat_id")]
        public int PokeathlonStatId { get; set; }

        [Column("max_change")]
        public int MaxChange { get; set; }
    }

    [Table("item_flavor_text")]
    public class ItemFlavorTextRow
    {
        [PrimaryKey]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("language_id")]
        public int LanguageId { get; set; }

        [Column("flavor_text")]
        public string FlavorText { get; set; }
    }

    [Table("item_game_indices")]
    public class ItemGameIndicesRow
    {
        [PrimaryKey]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("game_index")]
        public int GameIndex { get; set; }
    }

    [Table("item_flag_map")]
    public class ItemFlagMapRow
    {
        [PrimaryKey]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("item_flag_id")]
        public int ItemFlagId { get; set; }
    }

    [Table("move_effect_changelog")]
    public class MoveEffectChangelogRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("effect_id")]
        public int EffectId { get; set; }

        [Column("changed_in_version_group_id")]
        public int ChangedInVersionGroupId { get; set; }
    }

    [Table("item_prose")]
    public class ItemProseRow
    {
        [PrimaryKey]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("short_effect")]
        public string ShortEffect { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("versions")]
    public class VersionsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }
    }

    [Table("type_names")]
    public class TypeNamesRow
    {
        [PrimaryKey]
        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("nature_names")]
    public class NatureNamesRow
    {
        [PrimaryKey]
        [Column("nature_id")]
        public int NatureId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("version_group_pokemon_move_methods")]
    public class VersionGroupPokemonMoveMethodsRow
    {
        [PrimaryKey]
        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("pokemon_move_method_id")]
        public int PokemonMoveMethodId { get; set; }
    }

    [Table("moves")]
    public class MovesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("power")]
        public short? Power { get; set; }

        [Column("pp")]
        public short? Pp { get; set; }

        [Column("accuracy")]
        public short? Accuracy { get; set; }

        [Column("priority")]
        public short Priority { get; set; }

        [Column("target_id")]
        public int TargetId { get; set; }

        [Column("damage_class_id")]
        public int DamageClassId { get; set; }

        [Column("effect_id")]
        public int EffectId { get; set; }

        [Column("effect_chance")]
        public int? EffectChance { get; set; }

        [Column("contest_type_id")]
        public int? ContestTypeId { get; set; }

        [Column("contest_effect_id")]
        public int? ContestEffectId { get; set; }

        [Column("super_contest_effect_id")]
        public int? SuperContestEffectId { get; set; }
    }

    [Table("version_group_regions")]
    public class VersionGroupRegionsRow
    {
        [PrimaryKey]
        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }
    }

    [Table("evolution_chains")]
    public class EvolutionChainsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("baby_trigger_item_id")]
        public int? BabyTriggerItemId { get; set; }
    }

    [Table("conquest_kingdoms")]
    public class ConquestKingdomsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("type_id")]
        public int TypeId { get; set; }
    }

    [Table("nature_battle_style_preferences")]
    public class NatureBattleStylePreferencesRow
    {
        [PrimaryKey]
        [Column("nature_id")]
        public int NatureId { get; set; }

        [Column("move_battle_style_id")]
        public int MoveBattleStyleId { get; set; }

        [Column("low_hp_preference")]
        public int LowHpPreference { get; set; }

        [Column("high_hp_preference")]
        public int HighHpPreference { get; set; }
    }

    [Table("type_game_indices")]
    public class TypeGameIndicesRow
    {
        [PrimaryKey]
        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("game_index")]
        public int GameIndex { get; set; }
    }

    [Table("characteristic_text")]
    public class CharacteristicTextRow
    {
        [PrimaryKey]
        [Column("characteristic_id")]
        public int CharacteristicId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("message")]
        public string Message { get; set; }
    }

    [Table("conquest_warrior_transformation")]
    public class ConquestWarriorTransformationRow
    {
        [PrimaryKey]
        [Column("transformed_warrior_rank_id")]
        public int TransformedWarriorRankId { get; set; }

        [Column("is_automatic")]
        public bool IsAutomatic { get; set; }

        [Column("required_link")]
        public int? RequiredLink { get; set; }

        [Column("completed_episode_id")]
        public int? CompletedEpisodeId { get; set; }

        [Column("current_episode_id")]
        public int? CurrentEpisodeId { get; set; }

        [Column("distant_warrior_id")]
        public int? DistantWarriorId { get; set; }

        [Column("female_warlord_count")]
        public int? FemaleWarlordCount { get; set; }

        [Column("pokemon_count")]
        public int? PokemonCount { get; set; }

        [Column("collection_type_id")]
        public int? CollectionTypeId { get; set; }

        [Column("warrior_count")]
        public int? WarriorCount { get; set; }
    }

    [Table("berries")]
    public class BerriesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("firmness_id")]
        public int FirmnessId { get; set; }

        [Column("natural_gift_power")]
        public int? NaturalGiftPower { get; set; }

        [Column("natural_gift_type_id")]
        public int? NaturalGiftTypeId { get; set; }

        [Column("size")]
        public int Size { get; set; }

        [Column("max_harvest")]
        public int MaxHarvest { get; set; }

        [Column("growth_time")]
        public int GrowthTime { get; set; }

        [Column("soil_dryness")]
        public int SoilDryness { get; set; }

        [Column("smoothness")]
        public int Smoothness { get; set; }
    }

    [Table("conquest_move_data")]
    public class ConquestMoveDataRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("power")]
        public int? Power { get; set; }

        [Column("accuracy")]
        public int? Accuracy { get; set; }

        [Column("effect_chance")]
        public int? EffectChance { get; set; }

        [Column("effect_id")]
        public int EffectId { get; set; }

        [Column("range_id")]
        public int RangeId { get; set; }

        [Column("displacement_id")]
        public int? DisplacementId { get; set; }
    }

    [Table("conquest_transformation_warriors")]
    public class ConquestTransformationWarriorsRow
    {
        [PrimaryKey]
        [Column("transformation_id")]
        public int TransformationId { get; set; }

        [Column("present_warrior_id")]
        public int PresentWarriorId { get; set; }
    }

    [Table("move_flavor_summaries")]
    public class MoveFlavorSummariesRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("flavor_summary")]
        public string FlavorSummary { get; set; }
    }

    [Table("ability_changelog_prose")]
    public class AbilityChangelogProseRow
    {
        [PrimaryKey]
        [Column("ability_changelog_id")]
        public int AbilityChangelogId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("version_names")]
    public class VersionNamesRow
    {
        [PrimaryKey]
        [Column("version_id")]
        public int VersionId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("move_flag_map")]
    public class MoveFlagMapRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("move_flag_id")]
        public int MoveFlagId { get; set; }
    }

    [Table("move_meta_stat_changes")]
    public class MoveMetaStatChangesRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("stat_id")]
        public int StatId { get; set; }

        [Column("change")]
        public int Change { get; set; }
    }

    [Table("pokemon_species")]
    public class PokemonSpeciesRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("generation_id")]
        public int? GenerationId { get; set; }

        [Column("evolves_from_species_id")]
        public int? EvolvesFromSpeciesId { get; set; }

        [Column("evolution_chain_id")]
        public int? EvolutionChainId { get; set; }

        [Column("color_id")]
        public int ColorId { get; set; }

        [Column("shape_id")]
        public int ShapeId { get; set; }

        [Column("habitat_id")]
        public int? HabitatId { get; set; }

        [Column("gender_rate")]
        public int GenderRate { get; set; }

        [Column("capture_rate")]
        public int CaptureRate { get; set; }

        [Column("base_happiness")]
        public int BaseHappiness { get; set; }

        [Column("is_baby")]
        public bool IsBaby { get; set; }

        [Column("hatch_counter")]
        public int HatchCounter { get; set; }

        [Column("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [Column("growth_rate_id")]
        public int GrowthRateId { get; set; }

        [Column("forms_switchable")]
        public bool FormsSwitchable { get; set; }

        [Column("order")]
        public int Order { get; set; }

        [Column("conquest_order")]
        public int? ConquestOrder { get; set; }
    }

    [Table("machines")]
    public class MachinesRow
    {
        [PrimaryKey]
        [Column("machine_number")]
        public int MachineNumber { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("move_id")]
        public int MoveId { get; set; }
    }

    [Table("move_changelog")]
    public class MoveChangelogRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("changed_in_version_group_id")]
        public int ChangedInVersionGroupId { get; set; }

        [Column("type_id")]
        public int? TypeId { get; set; }

        [Column("power")]
        public short? Power { get; set; }

        [Column("pp")]
        public short? Pp { get; set; }

        [Column("accuracy")]
        public short? Accuracy { get; set; }

        [Column("effect_id")]
        public int? EffectId { get; set; }

        [Column("effect_chance")]
        public int? EffectChance { get; set; }
    }

    [Table("berry_flavors")]
    public class BerryFlavorsRow
    {
        [PrimaryKey]
        [Column("berry_id")]
        public int BerryId { get; set; }

        [Column("contest_type_id")]
        public int ContestTypeId { get; set; }

        [Column("flavor")]
        public int Flavor { get; set; }
    }

    [Table("super_contest_combos")]
    public class SuperContestCombosRow
    {
        [PrimaryKey]
        [Column("first_move_id")]
        public int FirstMoveId { get; set; }

        [Column("second_move_id")]
        public int SecondMoveId { get; set; }
    }

    [Table("conquest_kingdom_names")]
    public class ConquestKingdomNamesRow
    {
        [PrimaryKey]
        [Column("kingdom_id")]
        public int KingdomId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("move_flavor_text")]
    public class MoveFlavorTextRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("language_id")]
        public int LanguageId { get; set; }

        [Column("flavor_text")]
        public string FlavorText { get; set; }
    }

    [Table("location_area_encounter_rates")]
    public class LocationAreaEncounterRatesRow
    {
        [PrimaryKey]
        [Column("location_area_id")]
        public int LocationAreaId { get; set; }

        [Column("encounter_method_id")]
        public int EncounterMethodId { get; set; }

        [Column("version_id")]
        public int VersionId { get; set; }

        [Column("rate")]
        public int? Rate { get; set; }
    }

    [Table("move_names")]
    public class MoveNamesRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }

    [Table("move_meta")]
    public class MoveMetaRow
    {
        [PrimaryKey]
        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("meta_category_id")]
        public int MetaCategoryId { get; set; }

        [Column("meta_ailment_id")]
        public int MetaAilmentId { get; set; }

        [Column("min_hits")]
        public int? MinHits { get; set; }

        [Column("max_hits")]
        public int? MaxHits { get; set; }

        [Column("min_turns")]
        public int? MinTurns { get; set; }

        [Column("max_turns")]
        public int? MaxTurns { get; set; }

        [Column("drain")]
        public int Drain { get; set; }

        [Column("healing")]
        public int Healing { get; set; }

        [Column("crit_rate")]
        public int CritRate { get; set; }

        [Column("ailment_chance")]
        public int AilmentChance { get; set; }

        [Column("flinch_chance")]
        public int FlinchChance { get; set; }

        [Column("stat_chance")]
        public int StatChance { get; set; }
    }

    [Table("contest_combos")]
    public class ContestCombosRow
    {
        [PrimaryKey]
        [Column("first_move_id")]
        public int FirstMoveId { get; set; }

        [Column("second_move_id")]
        public int SecondMoveId { get; set; }
    }

    [Table("move_effect_changelog_prose")]
    public class MoveEffectChangelogProseRow
    {
        [PrimaryKey]
        [Column("move_effect_changelog_id")]
        public int MoveEffectChangelogId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("effect")]
        public string Effect { get; set; }
    }

    [Table("conquest_pokemon_stats")]
    public class ConquestPokemonStatsRow
    {
        [PrimaryKey]
        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }

        [Column("conquest_stat_id")]
        public int ConquestStatId { get; set; }

        [Column("base_stat")]
        public int BaseStat { get; set; }
    }

    [Table("conquest_pokemon_evolution")]
    public class ConquestPokemonEvolutionRow
    {
        [PrimaryKey]
        [Column("evolved_species_id")]
        public int EvolvedSpeciesId { get; set; }

        [Column("required_stat_id")]
        public int? RequiredStatId { get; set; }

        [Column("minimum_stat")]
        public int? MinimumStat { get; set; }

        [Column("minimum_link")]
        public int? MinimumLink { get; set; }

        [Column("kingdom_id")]
        public int? KingdomId { get; set; }

        [Column("warrior_gender_id")]
        public int? WarriorGenderId { get; set; }

        [Column("item_id")]
        public int? ItemId { get; set; }

        [Column("recruiting_ko_required")]
        public bool RecruitingKoRequired { get; set; }
    }

    [Table("pokemon_dex_numbers")]
    public class PokemonDexNumbersRow
    {
        [PrimaryKey]
        [Column("species_id")]
        public int SpeciesId { get; set; }

        [Column("pokedex_id")]
        public int PokedexId { get; set; }

        [Column("pokedex_number")]
        public int PokedexNumber { get; set; }
    }

    [Table("pokemon")]
    public class PokemonRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("species_id")]
        public int? SpeciesId { get; set; }

        [Column("height")]
        public int Height { get; set; }

        [Column("weight")]
        public int Weight { get; set; }

        [Column("base_experience")]
        public int BaseExperience { get; set; }

        [Column("order")]
        public int Order { get; set; }

        [Column("is_default")]
        public bool IsDefault { get; set; }
    }

    [Table("pokemon_egg_groups")]
    public class PokemonEggGroupsRow
    {
        [PrimaryKey]
        [Column("species_id")]
        public int SpeciesId { get; set; }

        [Column("egg_group_id")]
        public int EggGroupId { get; set; }
    }

    [Table("pokemon_evolution")]
    public class PokemonEvolutionRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("evolved_species_id")]
        public int EvolvedSpeciesId { get; set; }

        [Column("evolution_trigger_id")]
        public int EvolutionTriggerId { get; set; }

        [Column("trigger_item_id")]
        public int? TriggerItemId { get; set; }

        [Column("minimum_level")]
        public int? MinimumLevel { get; set; }

        [Column("gender_id")]
        public int? GenderId { get; set; }

        [Column("location_id")]
        public int? LocationId { get; set; }

        [Column("held_item_id")]
        public int? HeldItemId { get; set; }

        [Column("time_of_day")]
        public string TimeOfDay { get; set; }

        [Column("known_move_id")]
        public int? KnownMoveId { get; set; }

        [Column("known_move_type_id")]
        public int? KnownMoveTypeId { get; set; }

        [Column("minimum_happiness")]
        public int? MinimumHappiness { get; set; }

        [Column("minimum_beauty")]
        public int? MinimumBeauty { get; set; }

        [Column("minimum_affection")]
        public int? MinimumAffection { get; set; }

        [Column("relative_physical_stats")]
        public int? RelativePhysicalStats { get; set; }

        [Column("party_species_id")]
        public int? PartySpeciesId { get; set; }

        [Column("party_type_id")]
        public int? PartyTypeId { get; set; }

        [Column("trade_species_id")]
        public int? TradeSpeciesId { get; set; }

        [Column("needs_overworld_rain")]
        public bool NeedsOverworldRain { get; set; }

        [Column("turn_upside_down")]
        public bool TurnUpsideDown { get; set; }
    }

    [Table("conquest_pokemon_moves")]
    public class ConquestPokemonMovesRow
    {
        [PrimaryKey]
        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }

        [Column("move_id")]
        public int MoveId { get; set; }
    }

    [Table("pokemon_species_flavor_summaries")]
    public class PokemonSpeciesFlavorSummariesRow
    {
        [PrimaryKey]
        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("flavor_summary")]
        public string FlavorSummary { get; set; }
    }

    [Table("conquest_transformation_pokemon")]
    public class ConquestTransformationPokemonRow
    {
        [PrimaryKey]
        [Column("transformation_id")]
        public int TransformationId { get; set; }

        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }
    }

    [Table("pal_park")]
    public class PalParkRow
    {
        [PrimaryKey]
        [Column("species_id")]
        public int SpeciesId { get; set; }

        [Column("area_id")]
        public int AreaId { get; set; }

        [Column("base_score")]
        public int BaseScore { get; set; }

        [Column("rate")]
        public int Rate { get; set; }
    }

    [Table("conquest_pokemon_abilities")]
    public class ConquestPokemonAbilitiesRow
    {
        [PrimaryKey]
        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }

        [Column("slot")]
        public int Slot { get; set; }

        [Column("ability_id")]
        public int AbilityId { get; set; }
    }

    [Table("pokemon_species_prose")]
    public class PokemonSpeciesProseRow
    {
        [PrimaryKey]
        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("form_description")]
        public string FormDescription { get; set; }
    }

    [Table("pokemon_species_flavor_text")]
    public class PokemonSpeciesFlavorTextRow
    {
        [PrimaryKey]
        [Column("species_id")]
        public int SpeciesId { get; set; }

        [Column("version_id")]
        public int VersionId { get; set; }

        [Column("language_id")]
        public int LanguageId { get; set; }

        [Column("flavor_text")]
        public string FlavorText { get; set; }
    }

    [Table("conquest_max_links")]
    public class ConquestMaxLinksRow
    {
        [PrimaryKey]
        [Column("warrior_rank_id")]
        public int WarriorRankId { get; set; }

        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }

        [Column("max_link")]
        public int MaxLink { get; set; }
    }

    [Table("pokemon_species_names")]
    public class PokemonSpeciesNamesRow
    {
        [PrimaryKey]
        [Column("pokemon_species_id")]
        public int PokemonSpeciesId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("genus")]
        public string Genus { get; set; }
    }

    [Table("pokemon_items")]
    public class PokemonItemsRow
    {
        [PrimaryKey]
        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("version_id")]
        public int VersionId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("rarity")]
        public int Rarity { get; set; }
    }

    [Table("pokemon_forms")]
    public class PokemonFormsRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("identifier")]
        public string Identifier { get; set; }

        [Column("form_identifier")]
        public string FormIdentifier { get; set; }

        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("introduced_in_version_group_id")]
        public int? IntroducedInVersionGroupId { get; set; }

        [Column("is_default")]
        public bool IsDefault { get; set; }

        [Column("is_battle_only")]
        public bool IsBattleOnly { get; set; }

        [Column("is_mega")]
        public bool IsMega { get; set; }

        [Column("form_order")]
        public int FormOrder { get; set; }

        [Column("order")]
        public int Order { get; set; }
    }

    [Table("encounters")]
    public class EncountersRow
    {
        [PrimaryKey]
        [Column("id")]
        public int Id { get; set; }

        [Column("version_id")]
        public int VersionId { get; set; }

        [Column("location_area_id")]
        public int LocationAreaId { get; set; }

        [Column("encounter_slot_id")]
        public int EncounterSlotId { get; set; }

        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("min_level")]
        public int MinLevel { get; set; }

        [Column("max_level")]
        public int MaxLevel { get; set; }
    }

    [Table("pokemon_types")]
    public class PokemonTypesRow
    {
        [PrimaryKey]
        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("slot")]
        public int Slot { get; set; }
    }

    [Table("pokemon_abilities")]
    public class PokemonAbilitiesRow
    {
        [PrimaryKey]
        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("ability_id")]
        public int AbilityId { get; set; }

        [Column("is_hidden")]
        public bool IsHidden { get; set; }

        [Column("slot")]
        public int Slot { get; set; }
    }

    [Table("pokemon_moves")]
    public class PokemonMovesRow
    {
        [PrimaryKey]
        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("version_group_id")]
        public int VersionGroupId { get; set; }

        [Column("move_id")]
        public int MoveId { get; set; }

        [Column("pokemon_move_method_id")]
        public int PokemonMoveMethodId { get; set; }

        [Column("level")]
        public int Level { get; set; }

        [Column("order")]
        public int? Order { get; set; }
    }

    [Table("pokemon_game_indices")]
    public class PokemonGameIndicesRow
    {
        [PrimaryKey]
        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("version_id")]
        public int VersionId { get; set; }

        [Column("game_index")]
        public int GameIndex { get; set; }
    }

    [Table("pokemon_stats")]
    public class PokemonStatsRow
    {
        [PrimaryKey]
        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [Column("stat_id")]
        public int StatId { get; set; }

        [Column("base_stat")]
        public int BaseStat { get; set; }

        [Column("effort")]
        public int Effort { get; set; }
    }

    [Table("pokemon_form_generations")]
    public class PokemonFormGenerationsRow
    {
        [PrimaryKey]
        [Column("pokemon_form_id")]
        public int PokemonFormId { get; set; }

        [Column("generation_id")]
        public int GenerationId { get; set; }

        [Column("game_index")]
        public int GameIndex { get; set; }
    }

    [Table("pokemon_form_names")]
    public class PokemonFormNamesRow
    {
        [PrimaryKey]
        [Column("pokemon_form_id")]
        public int PokemonFormId { get; set; }

        [Column("local_language_id")]
        public int LocalLanguageId { get; set; }

        [Column("form_name")]
        public string FormName { get; set; }

        [Column("pokemon_name")]
        public string PokemonName { get; set; }
    }

    [Table("encounter_condition_value_map")]
    public class EncounterConditionValueMapRow
    {
        [PrimaryKey]
        [Column("encounter_id")]
        public int EncounterId { get; set; }

        [Column("encounter_condition_value_id")]
        public int EncounterConditionValueId { get; set; }
    }

    [Table("pokemon_form_pokeathlon_stats")]
    public class PokemonFormPokeathlonStatsRow
    {
        [PrimaryKey]
        [Column("pokemon_form_id")]
        public int PokemonFormId { get; set; }

        [Column("pokeathlon_stat_id")]
        public int PokeathlonStatId { get; set; }

        [Column("minimum_stat")]
        public int MinimumStat { get; set; }

        [Column("base_stat")]
        public int BaseStat { get; set; }

        [Column("maximum_stat")]
        public int MaximumStat { get; set; }
    }
}