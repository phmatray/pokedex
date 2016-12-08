using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Data;
using PokedexG.Uwp.Data.Services;
using PokedexG.Uwp.Services.VeekunServices.Business;
using PokemonAPI.Models.Rsc;
using Type = PokemonAPI.Models.Rsc.Type;

namespace PokedexG.Uwp.Models
{
    public class PokemonUiModel
    {
        private PokemonUiModel()
        {
        }

        public static async Task<PokemonUiModel> CreateAsync
            (VeekunContext context, int pokemonFormId, LanguagesEnum language, VersionGroupsEnum versionGroup)
        {
            var result                  = new PokemonUiModel();

            var pokemonFormsService     = new PokemonFormsService(context);
            var pokemonsService         = new PokemonsService(context);
            var pokemonSpeciesService   = new PokemonSpeciesService(context);
            var pokemonColorsService    = new PokemonColorsService(context);
            var pokemonShapesService    = new PokemonShapesService(context);
            var generationsService      = new GenerationsService(context);
            var growthRatesService      = new GrowthRatesService(context);
            var evolutionChainsService  = new EvolutionChainsService(context);

            var pokemonForm             = await pokemonFormsService.Get(pokemonFormId);
            var pokemon                 = await pokemonsService.GetAsync(pokemonForm.Pokemon.Id);
            var pokemonSpecies          = await pokemonSpeciesService.Get(pokemon.Species.Id);

            // identifiers
            result.FormId               = pokemonForm.Id;
            result.PokemonId            = pokemon.Id;
            result.SpecieId             = pokemonSpecies.Id;
            result.FormIdentifier       = pokemonForm.FormName;

            // miscanelleous
            result.GenderRate           = pokemonSpecies.GenderRate;
            result.CaptureRate          = pokemonSpecies.CaptureRate;
            result.BaseHappiness        = pokemonSpecies.BaseHappiness;
            result.HasGenderDifferences = pokemonSpecies.HasGenderDifferences;
            result.HatchCounter         = pokemonSpecies.HatchCounter;
            result.IsBaby               = pokemonSpecies.IsBaby;
            result.BaseExperience       = pokemon.BaseExperience;
            result.Height               = pokemon.Height;
            result.Weight               = pokemon.Weight;
            result.Order                = pokemonForm.Order;
            result.IsDefault            = pokemonForm.IsDefault;
            result.IsBattleOnly         = pokemonForm.IsBattleOnly;
            result.IsMega               = pokemonForm.IsMega;

            // pokedex number
            result.PokedexNumberNational = pokemonSpecies.PokedexNumbers.FirstOrDefault(x => x.Pokedex.Id == (int) PokedexesEnum.National)?.EntryNumber.ToString();
            result.PokedexNumberNationalFormated = result.GetPokedexNumberNationalFormated(false);
            result.PokedexNumberNationalFormatedWithSuffix = result.GetPokedexNumberNationalFormated();

            // names
            Func<LanguagesEnum, string> getName = lang
                => pokemonSpecies.Names.FirstOrDefault(x => x.Language.Id == (int)lang).NameValue;

            result.NameFr      = getName(LanguagesEnum.French);
            result.NameEn      = getName(LanguagesEnum.English);
            result.NameJp      = getName(LanguagesEnum.Japanese);
            result.NameRoomaji = getName(LanguagesEnum.OfficialRoomaji);

            // genus
            var genus = pokemonSpecies.Genera.FirstOrDefault(x => x.Language.Id == (int)language).GenusValue;
            switch (language)
            {
                case LanguagesEnum.English:
                    result.Genus = genus + " Pokemon";
                    break;
                case LanguagesEnum.French:
                    result.Genus = "Pokémon " + genus;
                    break;
            }

            // flavor texts
            Func<VersionsEnum, string> getFlavorText = version
                => pokemonSpecies
                    .FlavorTextEntries
                    .FirstOrDefault(x => x.Language.Id == (int) language && x.Version.Id == (int) version)
                    .FlavorTextValue
                    .Replace('\n', ' ');

            result.FlavorTextX  = getFlavorText(VersionsEnum.X);
            result.FlavorTextY  = getFlavorText(VersionsEnum.Y);
            result.FlavorTextOR = getFlavorText(VersionsEnum.OmegaRuby);
            result.FlavorTextAS = getFlavorText(VersionsEnum.AlphaSapphire);

            // abilities
            result.Abilities = new List<PokemonAbilityUiModel>();
            foreach (var x in pokemon.Abilities)
                result.Abilities.Add(await PokemonAbilityUiModel.CreateAsync(context, x, language, versionGroup));

            // color
            var pokemonColor = await pokemonColorsService.Get(pokemonSpecies.Color.Id);
            result.Color = pokemonColor.Names.FirstOrDefault(x => x.Language.Id == (int) language)?.NameValue;

            // growth rate name
            var growthRate    = await growthRatesService.Get(pokemonSpecies.GrowthRate.Id);
            result.GrowthRate = growthRate.Descriptions.FirstOrDefault(x => x.Language.Id == (int) language)?.DescriptionValue;
            result.Exp50      = growthRate.Levels.FirstOrDefault(x => x.Level == 50)?.Experience.ToString();
            result.Exp100     = growthRate.Levels.FirstOrDefault(x => x.Level == 100)?.Experience.ToString();

            // stats
            Func<string, int> getStat = statName
                => pokemon.Stats.FirstOrDefault(x => x.Stat.Name == statName).BaseStat;

            Func<string, int> getEffort = statName
                => pokemon.Stats.FirstOrDefault(x => x.Stat.Name == statName).Effort;

            result.BaseStatHp       = getStat("hp");
            result.BaseStatAtk      = getStat("attack");
            result.BaseStatDef      = getStat("defense");
            result.BaseStatAtkSpe   = getStat("special-attack");
            result.BaseStatDefSpe   = getStat("special-defense");
            result.BaseStatSpd      = getStat("speed");

            result.EffortStatHp     = getEffort("hp");
            result.EffortStatAtk    = getEffort("attack");
            result.EffortStatDef    = getEffort("defense");
            result.EffortStatAtkSpe = getEffort("special-attack");
            result.EffortStatDefSpe = getEffort("special-defense");
            result.EffortStatSpd    = getEffort("speed");

            // shape
            var pokemonShape        = await pokemonShapesService.Get(pokemonSpecies.Shape.Id);
            result.ShapeName        = pokemonShape.Names.FirstOrDefault(x => x.Language.Id == (int) language).NameValue;
            result.ShapeAwesomeName = pokemonShape.AwesomeNames.FirstOrDefault(x => x.Language.Id == (int) language).AwesomeNameValue;

            // types
            result.Types = new List<PokemonTypeUiModel>();
            foreach (var x in pokemon.Types)
                result.Types.Add(await PokemonTypeUiModel.CreateAsync(context, x, language));

            // weaknesses
            switch (result.Types.Count)
            {
                case 1:
                    result.Weaknesses = result.Types[0].DamageFrom
                        .Where(x => x.DamageFactor != 100)
                        .ToList();
                    break;
                case 2:
                    var type1DamageFrom = result.Types[0].DamageFrom;
                    var type2DamageFrom = result.Types[1].DamageFrom;
                    result.Weaknesses = PokemonBusiness.GetWeaknesses(type1DamageFrom, type2DamageFrom, true);
                    break;
            }

            // generation
            var generation = await generationsService.Get(pokemonSpecies.Generation.Id);
            result.GenerationName = generation.Names.FirstOrDefault(x => x.Language.Id == (int) language).NameValue;

            // moves 
            //pokemon.Moves.Where(x => x.VersionGroupDetails.)




            // evolution chains
            var evolutionChain = await evolutionChainsService.Get(pokemonSpecies.EvolutionChain.Id);
            //pokemonSpecies.EvolutionChain

            //evolutionChain.
            //foreach (var namedApiResource in pokemon.Forms)
            //{
            //    pokemonSpecies.f
            //    var form = await pokemonFormsService.Get(namedApiResource.Id);
            //    //form.IsMega;
            //}



            return result;
        }


        #region Properties

        public int FormId { get; set; }
        public int PokemonId { get; set; }
        public int SpecieId { get; set; }
        public string FormIdentifier { get; set; }
        public int Order { get; set; }
        public string PokedexNumberNational { get; set; }
        public string PokedexNumberNationalFormated { get; set; }
        public string PokedexNumberNationalFormatedWithSuffix { get; set; }
        public string NameFr { get; set; }
        public string NameEn { get; set; }
        public string NameJp { get; set; }
        public string NameRoomaji { get; set; }
        public string Genus { get; set; }
        public string FlavorTextX { get; set; }
        public string FlavorTextY { get; set; }
        public string FlavorTextOR { get; set; }
        public string FlavorTextAS { get; set; }
        public List<PokemonAbilityUiModel> Abilities { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public string GrowthRate { get; set; }
        public string Exp50 { get; set; }
        public string Exp100 { get; set; }
        public int BaseStatHp { get; set; }
        public int BaseStatAtk { get; set; }
        public int BaseStatDef { get; set; }
        public int BaseStatAtkSpe { get; set; }
        public int BaseStatDefSpe { get; set; }
        public int BaseStatSpd { get; set; }
        public int EffortStatHp { get; set; }
        public int EffortStatAtk { get; set; }
        public int EffortStatDef { get; set; }
        public int EffortStatAtkSpe { get; set; }
        public int EffortStatDefSpe { get; set; }
        public int EffortStatSpd { get; set; }
        public int HatchCounter { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public bool HasGenderDifferences { get; set; }
        public bool IsBaby { get; set; }
        public int BaseExperience { get; set; }
        public int GenderRate { get; set; }
        public string ShapeName { get; set; }
        public string ShapeAwesomeName { get; set; }
        public bool IsDefault { get; set; }
        public bool IsBattleOnly { get; set; }
        public bool IsMega { get; set; }
        public List<PokemonTypeUiModel> Types { get; set; }
        public List<DamageTypeUiModel> Weaknesses { get; set; }
        public string GenerationName { get; set; }

        public bool HasType2 => Types.Count == 2;
        public PokemonTypeUiModel Type1 => Types[0];
        public PokemonTypeUiModel Type2 => HasType2 ? Types[1] : null;

        public string FormKey
            => FormIdentifier != null ? $"{SpecieId}-{FormIdentifier}" : $"{SpecieId}";

        public string HeightFormated => PokemonBusiness.FormatHeight(Height);
        public string WeightFormated => PokemonBusiness.FormatWeight(Weight);

        public int MinStatHp => PokemonBusiness.CalculateHp(BaseStatHp, 0);
        public int MinStatAtk => PokemonBusiness.CalculateStat(BaseStatAtk, 0);
        public int MinStatDef => PokemonBusiness.CalculateStat(BaseStatDef, 0);
        public int MinStatAtkSpe => PokemonBusiness.CalculateStat(BaseStatAtkSpe, 0);
        public int MinStatDefSpe => PokemonBusiness.CalculateStat(BaseStatDefSpe, 0);
        public int MinStatSpd => PokemonBusiness.CalculateStat(BaseStatSpd, 0);

        public int MaxStatHp => PokemonBusiness.CalculateHp(BaseStatHp);
        public int MaxStatAtk => PokemonBusiness.CalculateStat(BaseStatAtk);
        public int MaxStatDef => PokemonBusiness.CalculateStat(BaseStatDef);
        public int MaxStatAtkSpe => PokemonBusiness.CalculateStat(BaseStatAtkSpe);
        public int MaxStatDefSpe => PokemonBusiness.CalculateStat(BaseStatDefSpe);
        public int MaxStatSpd => PokemonBusiness.CalculateStat(BaseStatSpd);

        public int BaseStatsTotal
            => BaseStatHp + BaseStatAtk + BaseStatDef + BaseStatAtkSpe + BaseStatDefSpe + BaseStatSpd;

        public decimal BaseStatsAverage
            => Math.Round((decimal)BaseStatsTotal / 6, 2);

        public int HatchSteps
            => (HatchCounter + 1) * 255;

        public bool IsMegaX
            => IsMega && (FormIdentifier?.EndsWith("x") ?? false);

        public bool IsMegaY
            => IsMega && (FormIdentifier?.EndsWith("y") ?? false);

        public bool IsPrimal
            => FormIdentifier == "primal";

        public bool IsAlternative
            => FormId > 10000 && !IsMega && !IsPrimal;

        #endregion
    }

    public class DamageTypeUiModel
    {
        private DamageTypeUiModel()
        {
            
        }

        public static DamageTypeUiModel Create(Type damageType, int damageFactor, LanguagesEnum language)
        {
            var result = new DamageTypeUiModel
            {
                DamageTypeId = damageType.Id,
                DamageTypeIdentifier = damageType.Name,
                DamageTypeName = damageType.Names.FirstOrDefault(x => x.Language.Id == (int) language).NameValue,
                DamageFactor = damageFactor
            };

            return result;
        }

        public int DamageTypeId { get; set; }
        public string DamageTypeIdentifier { get; set; }
        public string DamageTypeName { get; set; }
        public int DamageFactor { get; set; }

        public override string ToString()
        {
            return $"{DamageTypeName} = {DamageFactor}";
        }
    }

    public class PokemonTypeUiModel
    {
        private PokemonTypeUiModel()
        {
        }

        public static async Task<PokemonTypeUiModel> CreateAsync(VeekunContext context, PokemonType pokemonType, LanguagesEnum language)
        {
            var result = new PokemonTypeUiModel();

            var typesService = new TypesService(context);

            var types = await typesService.GetAllDetails(x => x.Id < 10000);
            var type = await typesService.Get(pokemonType.Type.Id);

            result.Id         = type.Id;
            result.Identifier = type.Name;
            result.Name       = type.Names.FirstOrDefault(x => x.Language.Id == (int) language).NameValue;
            result.Slot       = pokemonType.Slot;

            // weaknessess
            result.DamageFrom = new List<DamageTypeUiModel>();
            foreach (var x in type.DamageRelations.DoubleDamageFrom)
            {
                var damageType = types.First(y => y.Id == x.Id);
                result.DamageFrom.Add(DamageTypeUiModel.Create(damageType, 200, language));
            }

            foreach (var x in type.DamageRelations.NormalDamageFrom)
            {
                var damageType = types.First(y => y.Id == x.Id);
                result.DamageFrom.Add(DamageTypeUiModel.Create(damageType, 100, language));
            }

            foreach (var x in type.DamageRelations.HalfDamageFrom)
            {
                var damageType = types.First(y => y.Id == x.Id);
                result.DamageFrom.Add(DamageTypeUiModel.Create(damageType, 50, language));
            }

            foreach (var x in type.DamageRelations.NoDamageFrom)
            {
                var damageType = types.First(y => y.Id == x.Id);
                result.DamageFrom.Add(DamageTypeUiModel.Create(damageType, 0, language));
            }

            return result;
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int Slot { get; set; }
        public List<DamageTypeUiModel> DamageFrom { get; set; }
    }

    public class PokemonAbilityUiModel
    {
        private PokemonAbilityUiModel()
        {
        }

        public static async Task<PokemonAbilityUiModel> CreateAsync
            (VeekunContext context, PokemonAPI.Models.Rsc.PokemonAbility pokemonAbility, LanguagesEnum language, VersionGroupsEnum versionGroup)
        {
            var result = new PokemonAbilityUiModel();

            var abilitiesService = new AbilitiesService(context);

            var ability = await abilitiesService.Get(pokemonAbility.Ability.Id);

            result.Slot        = pokemonAbility.Slot;
            result.IsHidden    = pokemonAbility.IsHidden;
            result.Name        = ability.Names.FirstOrDefault(x => x.Language.Id == (int) language).NameValue;
            result.Effect      = ability.EffectEntries.FirstOrDefault(x => x.Language.Id == (int) language).Effect.CleanMarkdown();
            result.ShortEffect = ability.EffectEntries.FirstOrDefault(x => x.Language.Id == (int) language).ShortEffect.CleanMarkdown();

            result.FlavorText = ability.FlavorTextEntries
                .FirstOrDefault(x => x.Language.Id == (int)language && x.VersionGroup.Id == (int)versionGroup)
                .FlavorText;

            return result;
        }


        public int Slot { get; set; }
        public bool IsHidden { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public string ShortEffect { get; set; }
        public string FlavorText { get; set; }
    }
}