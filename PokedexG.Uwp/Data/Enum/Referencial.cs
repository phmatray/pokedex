using System.Collections.Generic;
using System.Threading.Tasks;
using PokedexG.Uwp.Data.Services;
using PokemonAPI.Models.Rsc;

namespace PokedexG.Uwp.Data
{
    public enum VersionGroupsEnum
    {
        RedBlue                = 1,
        Yellow                 = 2,
        GoldSilver             = 3,
        Crystal                = 4,
        RubySapphire           = 5,
        Emerald                = 6,
        FireredLeafgreen       = 7,
        DiamondPearl           = 8,
        Platinum               = 9,
        HeartgoldSoulsilver    = 10,
        BlackWhite             = 11,
        Colosseum              = 12,
        Xd                     = 13,
        BlackWhite2            = 14,
        XY                     = 15,
        OmegaRubyAlphaSapphire = 16
    }

    public enum VersionsEnum
    {
        Red           = 1,
        Blue          = 2,
        Yellow        = 3,
        Gold          = 4,
        Silver        = 5,
        Crystal       = 6,
        Ruby          = 7,
        Sapphire      = 8,
        Emerald       = 9,
        Firered       = 10,
        Leafgreen     = 11,
        Diamond       = 12,
        Pearl         = 13,
        Platinum      = 14,
        Heartgold     = 15,
        Soulsilver    = 16,
        Black         = 17,
        White         = 18,
        Colosseum     = 19,
        Xd            = 20,
        Black2        = 21,
        White2        = 22,
        X             = 23,
        Y             = 24,
        OmegaRuby     = 25,
        AlphaSapphire = 26
    }

    public enum StatsEnum
    {
        Hp             = 1,
        Attack         = 2,
        Defense        = 3,
        SpecialAttack  = 4,
        SpecialDefense = 5,
        Speed          = 6
    }

    public enum LanguagesEnum
    {
        Japanese        = 1,
        OfficialRoomaji = 2,
        Korean          = 3,
        Chinese         = 4,
        French          = 5,
        German          = 6,
        Spanish         = 7,
        Italian         = 8,
        English         = 9,
        Czech           = 10
    }

    public enum PokedexesEnum
    {
        National       = 1,
        Kanto          = 2,
        OriginalJohto  = 3,
        Hoenn          = 4,
        OriginalSinnoh = 5,
        ExtendedSinnoh = 6,
        UpdatedJohto   = 7,
        OriginalUnova  = 8,
        UpdatedUnova   = 9,
        KalosCentral   = 12,
        KalosCoastal   = 13,
        KalosMountain  = 14,
        UpdatedHoenn   = 15
    }

    public static class Referential
    {
        public static List<Language> Languages { get; set; }

        public static async Task Load()
        {
            var veekunContext = new VeekunContext();
            var languagesService = new LanguagesService(veekunContext);

            Languages = await languagesService.GetAllDetails(x => x.Official, 20, 0);
            
        }
    }
}                                                                                                                                          