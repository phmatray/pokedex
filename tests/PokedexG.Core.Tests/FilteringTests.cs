// Tests de caractérisation du filtre/tri du Pokédex (FilteredPokemonStore), sur les vraies
// données. Les bizarreries d'origine sont figées volontairement — dont la recherche par type :
// le type 1 est comparé SANS retirer les accents, le type 2 AVEC (quirk de 2016).
using System.Linq;
using System.Threading.Tasks;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Models.Filtering;
using PokedexG.Uwp.Services.VeekunServices;
using Xunit;

namespace PokedexG.Core.Tests;

public class FilteringTests
{
    private static async Task<FilteredPokemonStore> ChargerAsync()
    {
        var pokemons = await Veekun.GetPokemonsAsync();
        return new FilteredPokemonStore(new PokemonStore(pokemons));
    }

    [Fact]
    public async Task Filtre_par_nom_insensible_aux_accents_et_a_la_casse()
    {
        var store = await ChargerAsync();
        store.Filter = "dracau";
        store.RefreshView();

        Assert.Equal(3, store.Count);
        Assert.Equal(new[] { "Dracaufeu", "Méga-Dracaufeu X", "Méga-Dracaufeu Y" },
            store.Cast<Pokemon>().Select(x => x.Name).ToArray());
    }

    [Fact]
    public async Task Quirk_fige_le_type_1_reste_sensible_aux_accents_le_type_2_non()
    {
        var store = await ChargerAsync();
        store.Filter = "électrik";
        store.RefreshView();

        // Aucun match par le type 1 (« ÉLECTRIK » ≠ « ELECTRIK » sans normalisation),
        // 6 matchs par le type 2 (normalisé) — comportement 2016 conservé tel quel.
        Assert.Equal(6, store.Count);
        Assert.All(store.Cast<Pokemon>(), p => Assert.Equal("Électrik", p.Type2Name));
    }

    [Fact]
    public async Task Filtre_par_numero_formate()
    {
        var store = await ChargerAsync();
        store.Filter = "#150";
        store.RefreshView();

        Assert.Equal(new[] { "Mewtwo", "Méga-Mewtwo X", "Méga-Mewtwo Y" },
            store.Cast<Pokemon>().Select(x => x.Name).ToArray());
    }

    [Fact]
    public async Task Masquer_les_megas_retire_aussi_les_primo_resurgences()
    {
        var store = await ChargerAsync();
        store.IncludeMegaEvolutions = false;
        store.RefreshView();

        Assert.Equal(799 - 48 - 2, store.Count);
        Assert.DoesNotContain(store.Cast<Pokemon>(), p => p.IsMega || p.IsPrimal);
    }

    [Fact]
    public async Task Masquer_les_formes_alternatives()
    {
        var store = await ChargerAsync();
        store.IncludeAlternatives = false;
        store.RefreshView();

        Assert.Equal(799 - 28, store.Count);
    }

    [Fact]
    public async Task Tri_par_numero_est_un_tri_de_chaines()
    {
        var store = await ChargerAsync();
        store.SortMethod = PokemonSorting.ByNumber;
        store.RefreshView();

        var numeros = store.Cast<Pokemon>()
            .Select(x => x.PokedexNumberNationalFormatedWithSuffix).ToList();
        Assert.Equal(numeros.OrderBy(x => x).ToList(), numeros); // ordre lexicographique figé
        Assert.Equal("#001", numeros.First());
    }

    [Fact]
    public async Task Tri_par_famille_d_evolution_suit_l_ordre_des_formes()
    {
        var store = await ChargerAsync();
        store.SortMethod = PokemonSorting.ByEvolution;
        store.RefreshView();

        var ordres = store.Cast<Pokemon>().Select(x => x.Order).ToList();
        Assert.Equal(ordres.OrderBy(x => x).ToList(), ordres);
    }

    [Fact]
    public async Task PickRandom_pioche_dans_la_vue_filtree()
    {
        var store = await ChargerAsync();
        store.Filter = "dracau";
        store.RefreshView();

        var pioche = store.PickRandom();
        Assert.Contains("Dracaufeu", pioche.Name);
    }
}
