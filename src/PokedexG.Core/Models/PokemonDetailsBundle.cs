// Nouveau (2026-07-23) — agrégat de la fiche d'un Pokémon : regroupe en un seul document les
// cinq lectures que la page de détails UWP faisait séquentiellement à la navigation.
using System.Collections.Generic;

namespace PokedexG.Uwp.Models
{
    public class PokemonDetailsBundle
    {
        public PokemonDetails Details { get; set; }
        public List<PokemonAbility> Abilities { get; set; }
        public List<PokemonEgggroup> Egggroups { get; set; }
        public List<PokemonEvolution> Evolutions { get; set; }
        public List<Move> Moves { get; set; }
    }
}
