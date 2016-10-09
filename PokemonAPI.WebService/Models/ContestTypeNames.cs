namespace PokemonAPI.WebService.Models
{
    public partial class ContestTypeNames
    {
        public int ContestTypeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
        public string Color { get; set; }

        public virtual ContestTypes ContestType { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
