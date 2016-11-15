using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFTypeEfficacy : IEFModel
    {
        public int DamageTypeId { get; set; }
        public int TargetTypeId { get; set; }
        public int DamageFactor { get; set; }

        public virtual EFTypes DamageType { get; set; }
        public virtual EFTypes TargetType { get; set; }
    }
}
