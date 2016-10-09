namespace PokemonAPI.WebService.Models
{
    public partial class NaturePokeathlonStats
    {
        public int NatureId { get; set; }
        public int PokeathlonStatId { get; set; }
        public int MaxChange { get; set; }

        public virtual Natures Nature { get; set; }
        public virtual PokeathlonStats PokeathlonStat { get; set; }
    }
}
