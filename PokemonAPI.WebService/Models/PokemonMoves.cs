namespace PokemonAPI.WebService.Models
{
    public partial class PokemonMoves
    {
        public int PokemonId { get; set; }
        public int VersionGroupId { get; set; }
        public int MoveId { get; set; }
        public int PokemonMoveMethodId { get; set; }
        public int Level { get; set; }
        public int? Order { get; set; }

        public virtual Moves Move { get; set; }
        public virtual Pokemon Pokemon { get; set; }
        public virtual PokemonMoveMethods PokemonMoveMethod { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
