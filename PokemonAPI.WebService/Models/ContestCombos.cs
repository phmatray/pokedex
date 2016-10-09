namespace PokemonAPI.WebService.Models
{
    public partial class ContestCombos
    {
        public int FirstMoveId { get; set; }
        public int SecondMoveId { get; set; }

        public virtual Moves FirstMove { get; set; }
        public virtual Moves SecondMove { get; set; }
    }
}
