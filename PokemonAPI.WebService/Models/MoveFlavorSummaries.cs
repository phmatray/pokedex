namespace PokemonAPI.WebService.Models
{
    public partial class MoveFlavorSummaries
    {
        public int MoveId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorSummary { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual Moves Move { get; set; }
    }
}
