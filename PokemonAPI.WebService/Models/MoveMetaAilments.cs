using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class MoveMetaAilments
    {
        public MoveMetaAilments()
        {
            MoveMeta = new HashSet<MoveMeta>();
            MoveMetaAilmentNames = new HashSet<MoveMetaAilmentNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<MoveMeta> MoveMeta { get; set; }
        public virtual ICollection<MoveMetaAilmentNames> MoveMetaAilmentNames { get; set; }
    }
}
