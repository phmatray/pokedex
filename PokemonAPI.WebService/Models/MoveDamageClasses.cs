using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveDamageClasses : IEFModel, IEFIdentifier
    {
        public EFMoveDamageClasses()
        {
            MoveDamageClassProse = new HashSet<EFMoveDamageClassProse>();
            Moves = new HashSet<EFMoves>();
            Stats = new HashSet<EFStats>();
            Types = new HashSet<EFTypes>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFMoveDamageClassProse> MoveDamageClassProse { get; set; }
        public virtual ICollection<EFMoves> Moves { get; set; }
        public virtual ICollection<EFStats> Stats { get; set; }
        public virtual ICollection<EFTypes> Types { get; set; }
    }
}
