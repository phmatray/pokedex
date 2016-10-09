using System;
using PokedexG.Uwp.Services.VeekunServices.Business;

namespace PokedexG.Uwp.Models
{
    public class Pokemon : PokemonLite
    {
        public int FormId { get; set; }
        public string Identifier { get; set; }
        public bool IsDefault { get; set; }
        public bool IsBattleOnly { get; set; }
        public bool IsMega { get; set; }
        public int EvolutionChainId { get; set; }
        public int Order { get; set; }
        public int BaseStatHp { get; set; }
        public int BaseStatAtk { get; set; }
        public int BaseStatDef { get; set; }
        public int BaseStatAtkSpe { get; set; }
        public int BaseStatDefSpe { get; set; }
        public int BaseStatSpd { get; set; }
        public int? PokedexNumberNational { get; set; }
        public int Type1Id { get; set; }
        public string Type1Identifier { get; set; }
        public string Type1Name { get; set; }
        public int Type2Id { get; set; }
        public string Type2Identifier { get; set; }
        public string Type2Name { get; set; }

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

        public bool IsMegaX
            => IsMega && (FormIdentifier?.EndsWith("x") ?? false);

        public bool IsMegaY
            => IsMega && (FormIdentifier?.EndsWith("y") ?? false);

        public bool IsPrimal
            => FormIdentifier == "primal";

        public bool IsAlternative
            => FormId > 10000 && !IsMega && !IsPrimal;

        public string PokedexNumberNationalFormated
            => this.GetPokedexNumberNationalFormated(false);

        public string PokedexNumberNationalFormatedWithSuffix
            => this.GetPokedexNumberNationalFormated();
    }
}