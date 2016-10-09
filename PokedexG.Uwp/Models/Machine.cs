namespace PokedexG.Uwp.Models
{
    public class Machine
    {
        public int MachineNumber { get; set; }
        public string ItemIdentifier { get; set; }
        public int ItemCost { get; set; }
        public string ItemName { get; set; }
        public int TypeId { get; set; } // previously nullable
        public string Power { get; set; }// previously int?
        public string Pp { get; set; } // previously int?
        public string Accuracy { get; set; }// previously int?
        public int Priority { get; set; }
        public int? EffectChance { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string FlavorText { get; set; }
        public string Ailment { get; set; }
        public string Category { get; set; }
        public int AilmentId { get; set; }
        public int? MinHits { get; set; }
        public int? MaxHits { get; set; }
        public int? MinTurns { get; set; }
        public int? MaxTurns { get; set; }
        public int Drain { get; set; }
        public int Healing { get; set; }
        public int CritRate { get; set; }
        public int AilmentChance { get; set; }
        public int FlinchChance { get; set; }
        public int StatChance { get; set; }
        public string Type { get; set; }
        public string Generation { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string DamageClass { get; set; }
        public string ContestTypeName { get; set; }
        public string PokeblocFlavor { get; set; }
        public string PokeblocColor { get; set; }
        public string VersionGroup { get; set; }
        public string Targets { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}