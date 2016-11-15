using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFMoveFlavorText : IEFModel
    {
        public int MoveId { get; set; }
        public int VersionGroupId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual EFLanguages Language { get; set; }
        public virtual EFMoves Move { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
