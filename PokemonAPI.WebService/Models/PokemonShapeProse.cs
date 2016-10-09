namespace PokemonAPI.WebService.Models
{
    public partial class PokemonShapeProse
    {
        public int PokemonShapeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string AwesomeName { get; set; }
        public string Description { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokemonShapes PokemonShape { get; set; }
    }
}
