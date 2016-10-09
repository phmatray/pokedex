namespace PokedexG.Uwp.Models
{
    public class DamageType
    {
        public int DamageTypeId { get; set; }
        public string DamageTypeIdentifier { get; set; }
        public string DamageTypeName { get; set; }
        public int DamageFactor { get; set; }

        public override string ToString()
        {
            return $"{DamageTypeName} = {DamageFactor}";
        }
    }
}