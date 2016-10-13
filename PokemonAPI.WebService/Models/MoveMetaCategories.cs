using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveMetaCategories : IEFModel, IEFIdentifier
    {
        public EFMoveMetaCategories()
        {
            MoveMeta = new HashSet<EFMoveMeta>();
            MoveMetaCategoryProse = new HashSet<EFMoveMetaCategoryProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFMoveMeta> MoveMeta { get; set; }
        public virtual ICollection<EFMoveMetaCategoryProse> MoveMetaCategoryProse { get; set; }
    }
}
