using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestWarriorRanks : IEFModel
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

        public virtual ICollection<EFConquestMaxLinks> ConquestMaxLinks { get; set; }
        public virtual ICollection<EFConquestWarriorRankStatMap> ConquestWarriorRankStatMap { get; set; }
        public virtual EFConquestWarriorTransformation ConquestWarriorTransformation { get; set; }
        public virtual EFConquestWarriorSkills Skill { get; set; }
        public virtual EFConquestWarriors Warrior { get; set; }
    }
}
