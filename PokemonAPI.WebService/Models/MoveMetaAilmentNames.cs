namespace PokemonAPI.WebService.Models
{
    public partial class MoveMetaAilmentNames
    {
        public int MoveMetaAilmentId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveMetaAilments MoveMetaAilment { get; set; }
    }
}
