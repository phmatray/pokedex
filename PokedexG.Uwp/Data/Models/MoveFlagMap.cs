using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFMoveFlagMap : IEFModel
    {
        public int MoveId { get; set; }
        public int MoveFlagId { get; set; }

        public virtual EFMoveFlags MoveFlag { get; set; }
        public virtual EFMoves Move { get; set; }
    }
}
