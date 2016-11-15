using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFConquestWarriorStats : IEFIdentifier
    {
        public EFConquestWarriorStats()
        {
            ConquestWarriorRankStatMap = new HashSet<EFConquestWarriorRankStatMap>();
            ConquestWarriorStatNames = new HashSet<EFConquestWarriorStatNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFConquestWarriorRankStatMap> ConquestWarriorRankStatMap { get; set; }
        public ICollection<EFConquestWarriorStatNames> ConquestWarriorStatNames { get; set; }
    }
}
