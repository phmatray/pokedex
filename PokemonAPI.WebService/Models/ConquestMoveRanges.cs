using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestMoveRanges
    {
        public ConquestMoveRanges()
        {
            ConquestMoveData = new HashSet<ConquestMoveData>();
            ConquestMoveRangeProse = new HashSet<ConquestMoveRangeProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int Targets { get; set; }

        public virtual ICollection<ConquestMoveData> ConquestMoveData { get; set; }
        public virtual ICollection<ConquestMoveRangeProse> ConquestMoveRangeProse { get; set; }
    }
}
