using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestWarriorStats : IEFModel, IEFIdentifier
    {
        public EFConquestWarriorStats()
        {
            ConquestWarriorRankStatMap = new HashSet<EFConquestWarriorRankStatMap>();
            ConquestWarriorStatNames = new HashSet<EFConquestWarriorStatNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFConquestWarriorRankStatMap> ConquestWarriorRankStatMap { get; set; }
        public virtual ICollection<EFConquestWarriorStatNames> ConquestWarriorStatNames { get; set; }
    }
}
