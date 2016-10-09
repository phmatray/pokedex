namespace PokemonAPI.WebService.Models
{
    public partial class StatNames
    {
        public int StatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual Stats Stat { get; set; }
    }
}
