namespace PokemonAPI.WebService.Models
{
    public partial class MoveMetaStatChanges
    {
        public int MoveId { get; set; }
        public int StatId { get; set; }
        public int Change { get; set; }

        public virtual Moves Move { get; set; }
        public virtual Stats Stat { get; set; }
    }
}
