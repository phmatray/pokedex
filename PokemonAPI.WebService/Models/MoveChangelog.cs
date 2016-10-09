namespace PokemonAPI.WebService.Models
{
    public partial class MoveChangelog
    {
        public int MoveId { get; set; }
        public int ChangedInVersionGroupId { get; set; }
        public int? TypeId { get; set; }
        public short? Power { get; set; }
        public short? Pp { get; set; }
        public short? Accuracy { get; set; }
        public int? EffectId { get; set; }
        public int? EffectChance { get; set; }

        public virtual VersionGroups ChangedInVersionGroup { get; set; }
        public virtual MoveEffects Effect { get; set; }
        public virtual Moves Move { get; set; }
        public virtual Types Type { get; set; }
    }
}
