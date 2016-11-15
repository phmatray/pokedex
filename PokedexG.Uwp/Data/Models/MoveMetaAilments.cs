using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFMoveMetaAilments : IEFIdentifier
    {
        public EFMoveMetaAilments()
        {
            MoveMeta = new HashSet<EFMoveMeta>();
            MoveMetaAilmentNames = new HashSet<EFMoveMetaAilmentNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFMoveMeta> MoveMeta { get; set; }
        public ICollection<EFMoveMetaAilmentNames> MoveMetaAilmentNames { get; set; }
    }
}
