namespace PokemonAPI.WebService.Models
{
    public partial class ConquestPokemonMoves
    {
        public int PokemonSpeciesId { get; set; }
        public int MoveId { get; set; }

        public virtual Moves Move { get; set; }
        public virtual PokemonSpecies PokemonSpecies { get; set; }
    }
}
