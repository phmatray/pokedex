namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorSkillNames
    {
        public int SkillId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual ConquestWarriorSkills Skill { get; set; }
    }
}
