// Générateur de l'API statique : exécute les requêtes SQL de 2014 (verbatim) contre
// pokedex.sqlite (inchangé) et matérialise les réponses en JSON servis par le site.
// Usage : dotnet run --project src/PokedexG.DataGen [-- <dossier de sortie>]
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Services.VeekunServices;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr-FR");

var output = args.Length > 0
    ? args[0]
    : Path.Combine(FindRepoRoot(), "src", "PokedexG.Web", "wwwroot", "data");

var json = new JsonSerializerOptions
{
    IgnoreReadOnlyProperties = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};

Directory.CreateDirectory(output);
Directory.CreateDirectory(Path.Combine(output, "pokemon"));
Directory.CreateDirectory(Path.Combine(output, "type"));
Directory.CreateDirectory(Path.Combine(output, "egggroup"));

void Write(string relativePath, object value)
    => File.WriteAllText(Path.Combine(output, relativePath), JsonSerializer.Serialize(value, json));

// Listes globales — paramètres par défaut de l'app (version 25 Rubis Oméga, français).
var pokemons = await Veekun.GetPokemonsAsync();
Write("pokemons.json", pokemons);

Write("pokedexes.json", await Veekun.GetPokedexesAsync());
Write("versions.json", await Veekun.GetVersionsAsync());
var types = await Veekun.GetTypeLitesAsync();
Write("types.json", types);
Write("type-relations.json", await Veekun.GetTypeRelationsAsync());
Write("machines.json", await Veekun.GetMachinesAsync());

// Fiches par type : le type + ses Pokémon.
foreach (var type in types)
{
    Write(Path.Combine("type", $"{type.Id}.json"), new
    {
        Type = await Veekun.GetTypeAsync(type.Id),
        Pokemons = await Veekun.GetPokemonsByTypeAsync(type.Id)
    });
}

// Fiches par Pokémon — les cinq lectures que la page de détails faisait à la navigation.
var eggGroupIds = new SortedSet<int>();
var skipped = new List<int>();
foreach (var pokemon in pokemons)
{
    var details = await Veekun.GetPokemonAsync(pokemon.FormId);
    if (details == null)
    {
        // Comportement d'origine : ces formes faisaient échouer la page (retour à la liste).
        skipped.Add(pokemon.FormId);
        continue;
    }

    var bundle = new PokemonDetailsBundle
    {
        Details = details,
        Abilities = await Veekun.GetPokemonAbilitiesAsync(pokemon.PokemonId),
        Egggroups = await Veekun.GetPokemonEgggroupsAsync(pokemon.SpecieId),
        Evolutions = await Veekun.GetPokemonEvolutionsAsync(pokemon.SpecieId),
        Moves = await Veekun.GetMovesAsync(pokemon.PokemonId)
    };

    foreach (var eggGroup in bundle.Egggroups)
        eggGroupIds.Add(eggGroup.EggGroupId);

    Write(Path.Combine("pokemon", $"{pokemon.FormId}.json"), bundle);
}

// Membres par groupe d'œufs (onglet « Autres » / Reproduction).
foreach (var eggGroupId in eggGroupIds)
    Write(Path.Combine("egggroup", $"{eggGroupId}.json"),
        await Veekun.GetPokemonsByEgggroupAsync(eggGroupId));

Console.WriteLine($"OK — {pokemons.Count} pokémon, {types.Count} types, " +
                  $"{eggGroupIds.Count} groupes d'œufs → {output}");
if (skipped.Count > 0)
    Console.WriteLine($"Sans fiche (comme l'app d'origine : formes non par défaut) : " +
                      $"{skipped.Count} → {string.Join(", ", skipped)}");

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    while (dir != null && !File.Exists(Path.Combine(dir.FullName, "PokedexG.Blazor.sln")))
        dir = dir.Parent;
    if (dir == null)
        throw new DirectoryNotFoundException("PokedexG.Blazor.sln introuvable au-dessus du binaire.");
    return dir.FullName;
}
