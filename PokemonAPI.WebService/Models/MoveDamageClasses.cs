using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class MoveDamageClasses : INamedModel
    {
        public MoveDamageClasses()
        {
            MoveDamageClassProse = new HashSet<MoveDamageClassProse>();
            Moves = new HashSet<Moves>();
            Stats = new HashSet<Stats>();
            Types = new HashSet<Types>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<MoveDamageClassProse> MoveDamageClassProse { get; set; }
        public virtual ICollection<Moves> Moves { get; set; }
        public virtual ICollection<Stats> Stats { get; set; }
        public virtual ICollection<Types> Types { get; set; }
    }
}
