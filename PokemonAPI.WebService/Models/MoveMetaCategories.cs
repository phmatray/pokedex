using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class MoveMetaCategories
    {
        public MoveMetaCategories()
        {
            MoveMeta = new HashSet<MoveMeta>();
            MoveMetaCategoryProse = new HashSet<MoveMetaCategoryProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<MoveMeta> MoveMeta { get; set; }
        public virtual ICollection<MoveMetaCategoryProse> MoveMetaCategoryProse { get; set; }
    }
}
