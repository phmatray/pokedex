namespace PokemonAPI.WebService.Models
{
    public partial class PokedexVersionGroups
    {
        public int PokedexId { get; set; }
        public int VersionGroupId { get; set; }

        public virtual Pokedexes Pokedex { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
