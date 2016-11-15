using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFMoveMetaCategories : IEFIdentifier
    {
        public EFMoveMetaCategories()
        {
            MoveMeta = new HashSet<EFMoveMeta>();
            MoveMetaCategoryProse = new HashSet<EFMoveMetaCategoryProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFMoveMeta> MoveMeta { get; set; }
        public ICollection<EFMoveMetaCategoryProse> MoveMetaCategoryProse { get; set; }
    }
}
