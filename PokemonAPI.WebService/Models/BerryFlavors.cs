namespace PokemonAPI.WebService.Models
{
    public partial class BerryFlavors
    {
        public int BerryId { get; set; }
        public int ContestTypeId { get; set; }
        public int Flavor { get; set; }

        public virtual Berries Berry { get; set; }
        public virtual ContestTypes ContestType { get; set; }
    }
}
