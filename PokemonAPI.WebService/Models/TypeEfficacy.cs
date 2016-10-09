namespace PokemonAPI.WebService.Models
{
    public partial class TypeEfficacy
    {
        public int DamageTypeId { get; set; }
        public int TargetTypeId { get; set; }
        public int DamageFactor { get; set; }

        public virtual Types DamageType { get; set; }
        public virtual Types TargetType { get; set; }
    }
}
