namespace PokemonAPI.WebService.Models
{
    public partial class SuperContestCombos
    {
        public int FirstMoveId { get; set; }
        public int SecondMoveId { get; set; }

        public virtual Moves FirstMove { get; set; }
        public virtual Moves SecondMove { get; set; }
    }
}
