namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorStatNames
    {
        public int WarriorStatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual ConquestWarriorStats WarriorStat { get; set; }
    }
}
