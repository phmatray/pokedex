namespace PokemonAPI.WebService.Models
{
    public partial class ConquestMoveData
    {
        public int MoveId { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        public int? EffectChance { get; set; }
        public int EffectId { get; set; }
        public int RangeId { get; set; }
        public int? DisplacementId { get; set; }

        public virtual ConquestMoveDisplacements Displacement { get; set; }
        public virtual ConquestMoveEffects Effect { get; set; }
        public virtual Moves Move { get; set; }
        public virtual ConquestMoveRanges Range { get; set; }
    }
}
