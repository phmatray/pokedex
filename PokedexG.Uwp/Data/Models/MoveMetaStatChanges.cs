using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFMoveMetaStatChanges : IEFModel
    {
        public int MoveId { get; set; }
        public int StatId { get; set; }
        public int Change { get; set; }

        public virtual EFMoves Move { get; set; }
        public virtual EFStats Stat { get; set; }
    }
}
