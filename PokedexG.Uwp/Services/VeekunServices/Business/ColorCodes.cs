using Windows.UI;
using ColorHelper = Microsoft.Toolkit.Uwp.ColorHelper;

namespace PokedexG.Uwp.Services.VeekunServices.Business
{
    public static class ColorCodes
    {
        public static Color GetColorByTypeId(int? typeId)
        {
            switch (typeId)
            {
                case 1:     return ColorHelper.ToColor("#FFA8A878");
                case 2:     return ColorHelper.ToColor("#FF903028");
                case 3:     return ColorHelper.ToColor("#FFA890F0");
                case 4:     return ColorHelper.ToColor("#FFA040A0");
                case 5:     return ColorHelper.ToColor("#FFE0C068");
                case 6:     return ColorHelper.ToColor("#FFB8A038");
                case 7:     return ColorHelper.ToColor("#FFA8B820");
                case 8:     return ColorHelper.ToColor("#FF705898");
                case 9:     return ColorHelper.ToColor("#FFB8B8D0");
                case 10:    return ColorHelper.ToColor("#FFF05030");
                case 11:    return ColorHelper.ToColor("#FF68A090");
                case 12:    return ColorHelper.ToColor("#FF78C850");
                case 13:    return ColorHelper.ToColor("#FFF8D030");
                case 14:    return ColorHelper.ToColor("#FFF85888");
                case 15:    return ColorHelper.ToColor("#FF98D8D8");
                case 16:    return ColorHelper.ToColor("#FF7038F8");
                case 17:    return ColorHelper.ToColor("#FF705848");
                case 18:    return ColorHelper.ToColor("#FFF8A0E0");
                case 10001: return ColorHelper.ToColor("#FF68A090");
                case 10002: return ColorHelper.ToColor("#FF403246");
                default:    
                    return ColorHelper.ToColor("#00000000");
            }
        }

        public static Color GetColorByDamageIdentifier(string damageIdentifier)
        {
            switch (damageIdentifier)
            {
                case "status":   return ColorHelper.ToColor("#FF969296");
                case "physical": return ColorHelper.ToColor("#FFCE2918");
                case "special":  return ColorHelper.ToColor("#FF5A637B");
                default:
                    return ColorHelper.ToColor("#00000000");
            }
        }
    }
}
