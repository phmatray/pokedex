namespace PokemonAPI.Models.Resources
{
    public class TypeEfficacyResource
    {
        public int DamageFactor { get; set; }
        public NamedAPIResource DamageType { get; set; }
        public NamedAPIResource TargetType { get; set; }
    }
}