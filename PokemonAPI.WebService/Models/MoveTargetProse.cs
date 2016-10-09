namespace PokemonAPI.WebService.Models
{
    public partial class MoveTargetProse
    {
        public int MoveTargetId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveTargets MoveTarget { get; set; }
    }
}
