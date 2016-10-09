using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokedexProse : IName, IDescription
    {
        public int PokedexId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual Pokedexes Pokedex { get; set; }
    }
}
