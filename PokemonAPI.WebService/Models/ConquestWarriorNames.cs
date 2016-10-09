namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorNames
    {
        public int WarriorId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual ConquestWarriors Warrior { get; set; }
    }
}
