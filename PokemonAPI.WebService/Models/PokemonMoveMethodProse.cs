namespace PokemonAPI.WebService.Models
{
    public partial class PokemonMoveMethodProse
    {
        public int PokemonMoveMethodId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual PokemonMoveMethods PokemonMoveMethod { get; set; }
    }
}
