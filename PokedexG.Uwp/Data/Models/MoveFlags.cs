using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFMoveFlags : IEFIdentifier
    {
        public EFMoveFlags()
        {
            MoveFlagMap = new HashSet<EFMoveFlagMap>();
            MoveFlagProse = new HashSet<EFMoveFlagProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFMoveFlagMap> MoveFlagMap { get; set; }
        public ICollection<EFMoveFlagProse> MoveFlagProse { get; set; }
    }
}
