using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFConquestWarriorRanks : IEFModel
    {
        public EFConquestWarriorRanks()
        {
            ConquestMaxLinks = new HashSet<EFConquestMaxLinks>();
            ConquestWarriorRankStatMap = new HashSet<EFConquestWarriorRankStatMap>();
        }

        public int Id { get; set; }
        public int WarriorId { get; set; }
        public int Rank { get; set; }
        public int SkillId { get; set; }

        public ICollection<EFConquestMaxLinks> ConquestMaxLinks { get; set; }
        public ICollection<EFConquestWarriorRankStatMap> ConquestWarriorRankStatMap { get; set; }
        public EFConquestWarriorTransformation ConquestWarriorTransformation { get; set; }
        public EFConquestWarriorSkills Skill { get; set; }
        public EFConquestWarriors Warrior { get; set; }
    }
}
