namespace PokemonAPI.WebService.Models
{
    public partial class ConquestKingdomNames
    {
        public int KingdomId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual ConquestKingdoms Kingdom { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
