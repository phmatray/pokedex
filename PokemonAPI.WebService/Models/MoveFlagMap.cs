namespace PokemonAPI.WebService.Models
{
    public partial class MoveFlagMap
    {
        public int MoveId { get; set; }
        public int MoveFlagId { get; set; }

        public virtual MoveFlags MoveFlag { get; set; }
        public virtual Moves Move { get; set; }
    }
}
