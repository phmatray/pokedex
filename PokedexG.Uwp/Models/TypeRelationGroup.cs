using System.Collections.Generic;

namespace PokedexG.Uwp.Models
{
    public class TypeRelationGroup
    {
        public TypeLite Type { get; set; }
        public List<TypeRelation> TypeRelations { get; set; }
    }
}