namespace PokemonAPI.WebService.Models
{
    public partial class ConquestMoveDisplacementProse
    {
        public int MoveDisplacementId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual ConquestMoveDisplacements MoveDisplacement { get; set; }
    }
}
