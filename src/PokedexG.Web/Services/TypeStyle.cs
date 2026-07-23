// Styles des pastilles et badges — couleurs 2016 (ColorCodes), encres choisies par mesure
// WCAG AA (contrast-check.py) : le blanc systématique de 2016 échouait sur 13 des 18 types.
using PokedexG.Uwp.Services.VeekunServices.Business;

namespace PokedexG.Web.Services;

public static class TypeStyle
{
    private const string EncreSombre = "#231f1a";
    private const string EncreBlanche = "#ffffff";

    // Types dont le fond est assez sombre pour une encre blanche AA : Combat, Poison,
    // Spectre, Dragon, Ténèbres. Les 13 autres reçoivent l'encre sombre (mesuré).
    private static readonly HashSet<int> FondsSombres = new() { 2, 4, 8, 16, 17 };

    public static string Pastille(int? typeId)
        => $"background:{ColorCodes.GetColorByTypeId(typeId)};" +
           $"color:{(typeId is int id && FondsSombres.Contains(id) ? EncreBlanche : EncreSombre)}";

    public static string ClasseLabel(string? damageClassIdentifier) => damageClassIdentifier switch
    {
        "physical" => "PHYSIQUE",
        "special" => "SPÉCIAL",
        "status" => "STATUS", // libellé 2016 conservé tel quel (anglais dans l'app française)
        _ => ""
    };

    public static string ClasseStyle(string? damageClassIdentifier)
        => $"background:{ColorCodes.GetColorByDamageIdentifier(damageClassIdentifier)};" +
           $"color:{(damageClassIdentifier == "status" ? EncreSombre : EncreBlanche)}";

    /// <summary>Badge de la fiche (point de vue défenseur) : ×4 rouge … /4 vert.</summary>
    public static (string Label, string Style) BadgeFaiblesse(int facteur) => facteur switch
    {
        0 => ("0", "background:#000000;color:#ffffff"),
        25 => ("/4", $"background:#489820;color:{EncreSombre}"),
        50 => ("/2", $"background:#78C850;color:{EncreSombre}"),
        200 => ("x2", $"background:#F05030;color:{EncreSombre}"),
        400 => ("x4", "background:#C02000;color:#ffffff"),
        _ => ("1", "background:var(--bandeau);color:var(--encre)")
    };

    /// <summary>Cellule de la matrice (point de vue attaquant) : 2 et 4 verts, 0.25 rouge.</summary>
    public static (string Label, string Style) CelluleFacteur(int facteur) => facteur switch
    {
        0 => ("0", "background:#000000;color:#ffffff"),
        25 => ("0.25", "background:#C02000;color:#ffffff"),
        50 => ("0.5", $"background:#F05030;color:{EncreSombre}"),
        200 => ("2", $"background:#78C850;color:{EncreSombre}"),
        400 => ("4", $"background:#489820;color:{EncreSombre}"),
        _ => ("1", "background:transparent;color:var(--encre)")
    };

    /// <summary>Infobulle française de la matrice — formulations 2016 (TypeRelation.Sentence).</summary>
    public static string Phrase(string attaquant, string cible, int facteur) => facteur switch
    {
        0 => $"Le type {attaquant} n'affecte pas le type {cible}.",
        50 => $"Le type {attaquant} n'est pas très efficace contre le type {cible}.",
        200 => $"Le type {attaquant} est super efficace contre le type {cible}.",
        _ => $"Le type {attaquant} est constant contre le type {cible}."
    };
}
