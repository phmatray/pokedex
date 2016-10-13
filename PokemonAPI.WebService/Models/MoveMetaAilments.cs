using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveMetaAilments : IEFModel, IEFIdentifier
    {
        public EFMoveMetaAilments()
        {
            MoveMeta = new HashSet<EFMoveMeta>();
            MoveMetaAilmentNames = new HashSet<EFMoveMetaAilmentNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFMoveMeta> MoveMeta { get; set; }
        public virtual ICollection<EFMoveMetaAilmentNames> MoveMetaAilmentNames { get; set; }
    }
}
