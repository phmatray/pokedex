namespace PokemonAPI.WebService.Models
{
    public partial class PalPark
    {
        public int SpeciesId { get; set; }
        public int AreaId { get; set; }
        public int BaseScore { get; set; }
        public int Rate { get; set; }

        public virtual PalParkAreas Area { get; set; }
        public virtual PokemonSpecies Species { get; set; }
    }
}
