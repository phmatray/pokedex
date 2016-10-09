namespace PokemonAPI.WebService.Models
{
    public partial class ConquestMoveRangeProse
    {
        public int ConquestMoveRangeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ConquestMoveRanges ConquestMoveRange { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
