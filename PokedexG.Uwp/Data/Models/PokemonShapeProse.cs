using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFPokemonShapeProse : IEFModel
    {
        public int PokemonShapeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string AwesomeName { get; set; }
        public string Description { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonShapes PokemonShape { get; set; }
    }
}
