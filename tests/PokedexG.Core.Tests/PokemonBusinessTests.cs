// Tests de caractérisation de la logique métier portée verbatim (formats, formules, suffixes).
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Services.VeekunServices;
using PokedexG.Uwp.Services.VeekunServices.Business;
using PokedexG.Uwp.Utils;
using Xunit;

namespace PokedexG.Core.Tests;

public class PokemonBusinessTests
{
    public PokemonBusinessTests()
    {
        // L'app UWP tournait en fr-FR (DefaultLanguage du manifeste) ; les formats en dépendent.
        CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
    }

    [Theory]
    [InlineData(1, null, false, "#001")]
    [InlineData(6, "mega-x", true, "#006MX")]
    [InlineData(6, "mega-y", true, "#006MY")]
    [InlineData(150, "mega", true, "#150M")]
    public void Numero_national_formate_avec_suffixe_de_forme(
        int specieId, string? formIdentifier, bool isMega, string attendu)
    {
        var pokemon = new Pokemon { SpecieId = specieId, FormIdentifier = formIdentifier, IsMega = isMega };
        Assert.Equal(attendu, pokemon.GetPokedexNumberNationalFormated());
    }

    [Theory]
    [InlineData(201, "exclamation", "#201!")]
    [InlineData(201, "question", "#201?")]
    [InlineData(201, "a", "#201A")]
    [InlineData(666, "archipelago", "#666Arc")]
    [InlineData(487, "origin", "#487O")]
    [InlineData(479, "wash", "#479Wa")]
    public void Numero_national_cas_speciaux_Zarbi_Prismillon_Giratina_Motisma(
        int specieId, string formIdentifier, string attendu)
    {
        var pokemon = new Pokemon { SpecieId = specieId, FormIdentifier = formIdentifier };
        Assert.Equal(attendu, pokemon.GetPokedexNumberNationalFormated());
    }

    [Fact]
    public void Formules_de_stats_min_max_niveau_100()
    {
        Assert.Equal(294, PokemonBusiness.CalculateHp(45));       // PV max de Bulbizarre
        Assert.Equal(200, PokemonBusiness.CalculateHp(45, 0, 0)); // PV avec IV 0 et EV 0
        // Quirk figé : les « Min IVs » de la fiche UWP gardent les EV à 255 (défaut).
        Assert.Equal(263, PokemonBusiness.CalculateHp(45, 0));
        Assert.Equal(197, PokemonBusiness.CalculateStat(49));
        Assert.Equal(103, PokemonBusiness.CalculateStat(49, 0, 0));
    }

    [Fact]
    public void Formats_taille_et_poids_comme_la_fiche_UWP()
    {
        Assert.Equal("5'6\" (1.70 m)", PokemonBusiness.FormatHeight(17));
        Assert.Equal("199.52 lbs (90.5 kg)", PokemonBusiness.FormatWeight(905));
    }

    [Theory]
    [InlineData("[Ember]{move:ember} inflige des dégâts.", "Ember inflige des dégâts.")]
    [InlineData("[]{move:solar-beam} charge.", "solar-beam charge.")]
    [InlineData("Sans balisage.", "Sans balisage.")]
    public void CleanMarkdown_remplace_le_balisage_veekun(string source, string attendu)
    {
        Assert.Equal(attendu, source.CleanMarkdown());
    }

    [Fact]
    public async Task Faiblesses_Dracaufeu_Feu_Vol_facteurs_multiplies()
    {
        var relations = await Veekun.GetTypeRelationsAsync();
        var faiblesses = PokemonBusiness.GetWeaknesses(relations, 10, 3, excludeNeutral: true)
            .ToDictionary(x => x.DamageTypeName, x => x.DamageFactor);

        Assert.Equal(400, faiblesses["Roche"]);
        Assert.Equal(200, faiblesses["Eau"]);
        Assert.Equal(200, faiblesses["Électrik"]);
        Assert.Equal(0, faiblesses["Sol"]);      // Vol immunise contre le Sol
        Assert.Equal(25, faiblesses["Plante"]);
        Assert.Equal(10, faiblesses.Count);      // le neutre (100) est exclu
    }

    [Fact]
    public async Task Faiblesses_type_unique_Pikachu_Electrik()
    {
        var relations = await Veekun.GetTypeRelationsAsync();
        var faiblesses = PokemonBusiness.GetWeaknesses(relations, 13, 0, excludeNeutral: true)
            .ToDictionary(x => x.DamageTypeName, x => x.DamageFactor);

        Assert.Equal(200, faiblesses["Sol"]);
        Assert.Equal(50, faiblesses["Électrik"]);
        Assert.Equal(50, faiblesses["Vol"]);
        Assert.Equal(50, faiblesses["Acier"]);
        Assert.Equal(4, faiblesses.Count);
    }

    [Theory]
    [InlineData("mega-x", 1, "M")]
    [InlineData("attack", 2, "At")]
    [InlineData("archipelago", 3, "Arc")]
    [InlineData(null, 1, "")]
    public void StringHelper_Take_majuscule_puis_minuscules(string? source, int longueur, string attendu)
    {
        Assert.Equal(attendu, source.Take(longueur));
    }

    [Fact]
    public void StringHelper_RemoveDiacritics()
    {
        Assert.Equal("Electrik", "Électrik".RemoveDiacritics());
        Assert.Equal("Melofee", "Mélofée".RemoveDiacritics());
    }
}
