using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestWarriorSkills : IEFModel, IEFIdentifier
    {
        public EFConquestWarriorSkills()
        {
            ConquestWarriorRanks = new HashSet<EFConquestWarriorRanks>();
            ConquestWarriorSkillNames = new HashSet<EFConquestWarriorSkillNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFConquestWarriorRanks> ConquestWarriorRanks { get; set; }
        public virtual ICollection<EFConquestWarriorSkillNames> ConquestWarriorSkillNames { get; set; }
    }
}
