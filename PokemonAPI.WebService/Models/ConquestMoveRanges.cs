using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestMoveRanges : IEFModel, IEFIdentifier
    {
        public EFConquestMoveRanges()
        {
            ConquestMoveData = new HashSet<EFConquestMoveData>();
            ConquestMoveRangeProse = new HashSet<EFConquestMoveRangeProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int Targets { get; set; }

        public virtual ICollection<EFConquestMoveData> ConquestMoveData { get; set; }
        public virtual ICollection<EFConquestMoveRangeProse> ConquestMoveRangeProse { get; set; }
    }
}
