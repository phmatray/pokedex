using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestWarriorSpecialties : IEFModel
    {
        public int WarriorId { get; set; }
        public int TypeId { get; set; }
        public int Slot { get; set; }

        public virtual EFTypes Type { get; set; }
        public virtual EFConquestWarriors Warrior { get; set; }
    }
}
