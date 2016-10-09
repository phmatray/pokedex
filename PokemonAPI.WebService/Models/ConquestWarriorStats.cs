using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorStats
    {
        public ConquestWarriorStats()
        {
            ConquestWarriorRankStatMap = new HashSet<ConquestWarriorRankStatMap>();
            ConquestWarriorStatNames = new HashSet<ConquestWarriorStatNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<ConquestWarriorRankStatMap> ConquestWarriorRankStatMap { get; set; }
        public virtual ICollection<ConquestWarriorStatNames> ConquestWarriorStatNames { get; set; }
    }
}
