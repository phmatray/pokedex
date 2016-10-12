using System.Collections.Generic;

namespace PokemonAPI.Models.Resources.Pokemon.Natures
{
    /// <summary>
    /// Natures influence how a Pokémon's stats grow. See Bulbapedia for greater detail.
    /// </summary>
    public class NatureResources
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public NamedAPIResource DecreasedStat { get; set; }
        public NamedAPIResource IncreasedStat { get; set; }
        public NamedAPIResource HatesFlavor { get; set; }
        public NamedAPIResource LikesFlavor { get; set; }
        public List<NatureStatChangeResource> PokeathlonStatChanges { get; set; }
        public List<MoveBattleStylePreferenceResource> MoveBattleStylePreferences { get; set; }
        public List<NameResource> Names { get; set; }
    }
}