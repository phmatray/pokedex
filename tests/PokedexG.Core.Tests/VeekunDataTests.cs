// Tests de caractérisation — figent ce que les requêtes de 2014 renvoient réellement
// contre pokedex.sqlite (inchangé), paramètres par défaut de l'app (v25 Rubis Oméga, français).
using System.Linq;
using System.Threading.Tasks;
using PokedexG.Uwp.Services.VeekunServices;
using PokedexG.Uwp.Services.VeekunServices.Business;
using Xunit;

namespace PokedexG.Core.Tests;

public class VeekunDataTests
{
    [Fact]
    public async Task GetPokemons_renvoie_799_formes_dans_l_ordre_du_pokedex()
    {
        var pokemons = await Veekun.GetPokemonsAsync();

        Assert.Equal(799, pokemons.Count);
        var premier = pokemons.First();
        Assert.Equal("Bulbizarre", premier.Name);
        Assert.Equal(1, premier.FormId);
        Assert.Equal(45, premier.BaseStatHp);
        Assert.Equal(49, premier.BaseStatAtk);
        Assert.Equal(49, premier.BaseStatDef);
        Assert.Equal(65, premier.BaseStatAtkSpe);
        Assert.Equal(65, premier.BaseStatDefSpe);
        Assert.Equal(45, premier.BaseStatSpd);
        Assert.Equal("Plante", premier.Type1Name);
        Assert.Equal("Poison", premier.Type2Name);
        Assert.Equal(318, premier.BaseStatsTotal);
    }

    [Fact]
    public async Task GetPokemons_contient_48_megas_2_primo_28_formes_alternatives()
    {
        var pokemons = await Veekun.GetPokemonsAsync();

        Assert.Equal(48, pokemons.Count(x => x.IsMega));
        Assert.Equal(2, pokemons.Count(x => x.IsPrimal));
        Assert.Equal(28, pokemons.Count(x => x.IsAlternative));
    }

    [Fact]
    public async Task GetPokemon_Dracaufeu_fiche_complete_en_francais()
    {
        var d = await Veekun.GetPokemonAsync(6);

        Assert.Equal("Dracaufeu", d.NameFr);
        Assert.Equal("Charizard", d.NameEn);
        Assert.Equal("Flamme", d.Genus);
        Assert.Equal("Rouge", d.ColorName);
        Assert.Equal(45, d.CaptureRate);
        Assert.Equal(17, d.Height);
        Assert.Equal(905, d.Weight);
        Assert.Equal(3, d.EffortStatAtkSpe);
        Assert.StartsWith("Quand il crache son souffle brûlant", d.FlavorTextX);
        Assert.Equal(5355, d.HatchSteps); // (HatchCounter 20 + 1) × 255 pas
    }

    [Fact]
    public async Task GetPokemonAbilities_Dracaufeu_Brasier_et_talent_cache_Force_Soleil()
    {
        var talents = await Veekun.GetPokemonAbilitiesAsync(6);

        Assert.Equal(2, talents.Count);
        Assert.Equal("Brasier", talents[0].AbilityName);
        Assert.False(talents[0].IsHidden);
        Assert.Equal("Force Soleil", talents[1].AbilityName);
        Assert.True(talents[1].IsHidden);
    }

    [Fact]
    public async Task GetPokemonEvolutions_famille_Dracaufeu_stades_et_megas()
    {
        var evolutions = await Veekun.GetPokemonEvolutionsAsync(6);
        Assert.Equal(9, evolutions.Count);

        var famille = evolutions.GetStade();
        var stades = famille.EvolutionStades.Select(x => x.Name).ToList();
        // Quirks figés : la requête ne renvoie pas IsMega (le stade « Méga » du code UWP ne
        // s'affichait jamais) et triplique chaque évolution (fan-out de jointure — l'UWP
        // affichait bien Salamèche trois fois ; l'UI Blazor dédoublonne, divergence assumée).
        Assert.Equal(new[] { "Stade 1", "Stade 2", "Stade 3" }, stades);
        Assert.Equal(3, famille.EvolutionStades[0].Evolutions.Count);
        Assert.All(famille.EvolutionStades[0].Evolutions, e => Assert.Equal("Salamèche", e.NameFr));
    }

    [Fact]
    public async Task GetMoves_Dracaufeu_20_attaques_par_montee_de_niveau()
    {
        var attaques = await Veekun.GetMovesAsync(6);
        Assert.Equal(20, attaques.Count);
        Assert.All(attaques, a => Assert.Equal("level-up", a.MoveMethod));
    }

    [Fact]
    public async Task GetPokemonEgggroups_Dracaufeu_Monstrueux_et_Draconique()
    {
        var groupes = await Veekun.GetPokemonEgggroupsAsync(6);
        Assert.Equal(new[] { "Monstrueux", "Draconique" },
            groupes.Select(x => x.EggGroupName).ToArray());
    }

    [Fact]
    public async Task GetTypeLites_les_18_types_en_francais()
    {
        var types = await Veekun.GetTypeLitesAsync();
        Assert.Equal(18, types.Count);
        Assert.Equal("Normal", types.First().Name);
        Assert.Contains(types, t => t.Name == "Fée");
    }

    [Fact]
    public async Task GetTypeRelations_la_matrice_complete_18x18()
    {
        var relations = await Veekun.GetTypeRelationsAsync();
        Assert.Equal(324, relations.Count);
    }

    [Fact]
    public async Task GetMachines_les_100_CT_de_XY()
    {
        var machines = await Veekun.GetMachinesAsync();
        Assert.Equal(100, machines.Count);
        Assert.Equal("CT01", machines.First().ItemName);
    }

    [Fact]
    public async Task GetVersions_28_lignes_premiere_Rouge()
    {
        var versions = await Veekun.GetVersionsAsync();
        Assert.Equal(28, versions.Count);
        Assert.Equal("Rouge", versions.First().Name);
    }

    [Fact]
    public async Task GetPokedexes_requete_reconstruite_17_lignes_premiere_National()
    {
        var pokedexes = await Veekun.GetPokedexesAsync();
        Assert.Equal(17, pokedexes.Count);
        Assert.Equal("National", pokedexes.First().Name);
        Assert.Equal("Pokédex National complet", pokedexes.First().Description);
    }

    [Fact]
    public async Task GetPokemonsByType_65_pokemon_de_type_Feu()
    {
        var pokemons = await Veekun.GetPokemonsByTypeAsync(10);
        Assert.Equal(65, pokemons.Count);
        Assert.Equal("Salamèche", pokemons.First().Name);
    }

    [Fact]
    public async Task GetPokemonsByEgggroup_75_pokemon_du_groupe_Monstrueux()
    {
        var pokemons = await Veekun.GetPokemonsByEgggroupAsync(1);
        Assert.Equal(75, pokemons.Count);
        Assert.Equal("Bulbizarre", pokemons.First().Name);
    }
}
