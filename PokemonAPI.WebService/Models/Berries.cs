using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class Berries
    {
        public Berries()
        {
            BerryFlavors = new HashSet<BerryFlavors>();
        }

        public int Id { get; set; }
        public int ItemId { get; set; }
        public int FirmnessId { get; set; }
        public int? NaturalGiftPower { get; set; }
        public int? NaturalGiftTypeId { get; set; }
        public int Size { get; set; }
        public int MaxHarvest { get; set; }
        public int GrowthTime { get; set; }
        public int SoilDryness { get; set; }
        public int Smoothness { get; set; }

        public virtual ICollection<BerryFlavors> BerryFlavors { get; set; }
        public virtual BerryFirmness Firmness { get; set; }
        public virtual Items Item { get; set; }
        public virtual Types NaturalGiftType { get; set; }
    }
}
