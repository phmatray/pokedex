using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveFlags : IEFModel, IEFIdentifier
    {
        public EFMoveFlags()
        {
            MoveFlagMap = new HashSet<EFMoveFlagMap>();
            MoveFlagProse = new HashSet<EFMoveFlagProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFMoveFlagMap> MoveFlagMap { get; set; }
        public virtual ICollection<EFMoveFlagProse> MoveFlagProse { get; set; }
    }
}
