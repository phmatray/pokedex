using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFConquestWarriorSkills : IEFIdentifier
    {
        public EFConquestWarriorSkills()
        {
            ConquestWarriorRanks = new HashSet<EFConquestWarriorRanks>();
            ConquestWarriorSkillNames = new HashSet<EFConquestWarriorSkillNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFConquestWarriorRanks> ConquestWarriorRanks { get; set; }
        public ICollection<EFConquestWarriorSkillNames> ConquestWarriorSkillNames { get; set; }
    }
}
