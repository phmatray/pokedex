namespace PokemonAPI.WebService.Models
{
    public partial class PokemonFormGenerations
    {
        public int PokemonFormId { get; set; }
        public int GenerationId { get; set; }
        public int GameIndex { get; set; }

        public virtual Generations Generation { get; set; }
        public virtual PokemonForms PokemonForm { get; set; }
    }
}
