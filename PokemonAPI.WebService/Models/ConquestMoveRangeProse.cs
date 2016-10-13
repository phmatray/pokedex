using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestMoveRangeProse : IEFModel
    {
        public int ConquestMoveRangeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual EFConquestMoveRanges ConquestMoveRange { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
