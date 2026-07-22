// RECONSTRUCTION 2026-07-23 — Windows.UI.Color remplacé par la chaîne CSS ; les valeurs
// hexadécimales sont celles de l'original (alpha FF omis, opaque en CSS).
namespace PokedexG.Uwp.Services.VeekunServices.Business
{
    public static class ColorCodes
    {
        public const string Transparent = "transparent";

        public static string GetColorByTypeId(int? typeId)
        {
            switch (typeId)
            {
                case 1:     return "#A8A878";
                case 2:     return "#903028";
                case 3:     return "#A890F0";
                case 4:     return "#A040A0";
                case 5:     return "#E0C068";
                case 6:     return "#B8A038";
                case 7:     return "#A8B820";
                case 8:     return "#705898";
                case 9:     return "#B8B8D0";
                case 10:    return "#F05030";
                case 11:    return "#68A090";
                case 12:    return "#78C850";
                case 13:    return "#F8D030";
                case 14:    return "#F85888";
                case 15:    return "#98D8D8";
                case 16:    return "#7038F8";
                case 17:    return "#705848";
                case 18:    return "#F8A0E0";
                case 10001: return "#68A090";
                case 10002: return "#403246";
                default:
                    return Transparent;
            }
        }

        public static string GetColorByDamageIdentifier(string damageIdentifier)
        {
            switch (damageIdentifier)
            {
                case "status":   return "#969296";
                case "physical": return "#CE2918";
                case "special":  return "#5A637B";
                default:
                    return Transparent;
            }
        }
    }
}
