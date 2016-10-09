using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorRanks
    {
        public ConquestWarriorRanks()
        {
            ConquestMaxLinks = new HashSet<ConquestMaxLinks>();
            ConquestWarriorRankStatMap = new HashSet<ConquestWarriorRankStatMap>();
        }

        public int Id { get; set; }
        public int WarriorId { get; set; }
        public int Rank { get; set; }
        public int SkillId { get; set; }

        public virtual ICollection<ConquestMaxLinks> ConquestMaxLinks { get; set; }
        public virtual ICollection<ConquestWarriorRankStatMap> ConquestWarriorRankStatMap { get; set; }
        public virtual ConquestWarriorTransformation ConquestWarriorTransformation { get; set; }
        public virtual ConquestWarriorSkills Skill { get; set; }
        public virtual ConquestWarriors Warrior { get; set; }
    }
}
