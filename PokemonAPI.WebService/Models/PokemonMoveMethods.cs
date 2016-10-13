using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFPokemonMoveMethods : IEFModel, IEFIdentifier
    {
        public EFPokemonMoveMethods()
        {
            PokemonMoveMethodProse = new HashSet<EFPokemonMoveMethodProse>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            VersionGroupPokemonMoveMethods = new HashSet<EFVersionGroupPokemonMoveMethods>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFPokemonMoveMethodProse> PokemonMoveMethodProse { get; set; }
        public virtual ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public virtual ICollection<EFVersionGroupPokemonMoveMethods> VersionGroupPokemonMoveMethods { get; set; }
    }
}
