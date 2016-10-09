using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class PokemonMoveMethods : INamedModel
    {
        public PokemonMoveMethods()
        {
            PokemonMoveMethodProse = new HashSet<PokemonMoveMethodProse>();
            PokemonMoves = new HashSet<PokemonMoves>();
            VersionGroupPokemonMoveMethods = new HashSet<VersionGroupPokemonMoveMethods>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<PokemonMoveMethodProse> PokemonMoveMethodProse { get; set; }
        public virtual ICollection<PokemonMoves> PokemonMoves { get; set; }
        public virtual ICollection<VersionGroupPokemonMoveMethods> VersionGroupPokemonMoveMethods { get; set; }
    }
}
