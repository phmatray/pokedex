// Les couleurs de types/classes de dégâts de l'UWP, reconstruites en CSS — valeurs identiques.
using PokedexG.Uwp.Services.VeekunServices.Business;
using Xunit;

namespace PokedexG.Core.Tests;

public class ColorCodesTests
{
    [Theory]
    [InlineData(10, "#F05030")]  // Feu
    [InlineData(12, "#78C850")]  // Plante
    [InlineData(13, "#F8D030")]  // Électrik
    [InlineData(18, "#F8A0E0")]  // Fée
    [InlineData(999, ColorCodes.Transparent)]
    public void Couleur_par_type(int typeId, string attendu)
    {
        Assert.Equal(attendu, ColorCodes.GetColorByTypeId(typeId));
    }

    [Theory]
    [InlineData("physical", "#CE2918")]
    [InlineData("special", "#5A637B")]
    [InlineData("status", "#969296")]
    [InlineData("autre", ColorCodes.Transparent)]
    public void Couleur_par_classe_de_degats(string identifier, string attendu)
    {
        Assert.Equal(attendu, ColorCodes.GetColorByDamageIdentifier(identifier));
    }
}
