using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFSuperContestCombos : IEFModel
    {
        public int FirstMoveId { get; set; }
        public int SecondMoveId { get; set; }

        public virtual EFMoves FirstMove { get; set; }
        public virtual EFMoves SecondMove { get; set; }
    }
}
