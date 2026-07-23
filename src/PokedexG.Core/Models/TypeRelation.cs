namespace PokedexG.Uwp.Models
{
    public class TypeRelation
    {
        public int DamageTypeId { get; set; }
        public string DamageTypeIdentifier { get; set; }
        public string DamageTypeName { get; set; }
        public int TargetTypeId { get; set; }
        public string TargetTypeIdentifier { get; set; }
        public string TargetTypeName { get; set; }
        public int DamageFactor { get; set; }

        public string Sentence
        {
            get
            {
                switch (DamageFactor)
                {
                    case 0:
                        return $"Le type {DamageTypeName} n'affecte pas le type {TargetTypeName}.";
                    case 50:
                        return $"Le type {DamageTypeName} n'est pas très efficace contre le type {TargetTypeName}.";
                    case 100:
                        return $"Le type {DamageTypeName} est constant contre le type {TargetTypeName}.";
                    case 200:
                        return $"Le type {DamageTypeName} est super efficace contre le type {TargetTypeName}.";
                    default:
                        return string.Empty;
                }
            }
        }

        public override string ToString()
        {
            return $"{DamageTypeName} => {TargetTypeName} = {DamageFactor}";
        }
    }
}