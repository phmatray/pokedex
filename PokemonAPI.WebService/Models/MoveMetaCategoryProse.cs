namespace PokemonAPI.WebService.Models
{
    public partial class MoveMetaCategoryProse
    {
        public int MoveMetaCategoryId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Description { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveMetaCategories MoveMetaCategory { get; set; }
    }
}
