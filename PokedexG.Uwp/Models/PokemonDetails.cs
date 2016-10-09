using PokedexG.Uwp.Services.VeekunServices.Business;

namespace PokedexG.Uwp.Models
{
    public class PokemonDetails : Pokemon
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public int BaseExperience { get; set; }
        public int GenerationId { get; set; }
        public int? EvolveFromSpeciesId { get; set; }
        public int? HabitatId { get; set; }
        public int GenderRate { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public bool IsBaby { get; set; }
        public int HatchCounter { get; set; }
        public bool HasGenderDifference { get; set; }
        public int GrowthRateId { get; set; }
        public bool FormSwitchable { get; set; }
        public string GrowthRateName { get; set; }
        public string GenerationName { get; set; }
        public string ColorName { get; set; }
        public string ShapeName { get; set; }
        public string ShapeAwesomeName { get; set; }
        public string Genus { get; set; }
        public string NameFr { get; set; }
        public string Language { get; set; }
        public string NameEn { get; set; }
        public string NameJp { get; set; }
        public string NameJpRoomaji { get; set; }
        public string FlavorTextX { get; set; }
        public string FlavorTextY { get; set; }
        public string FlavorTextOmegaRuby { get; set; }
        public string FlavorTextAlphaSapphire { get; set; }
        public int EffortStatHp { get; set; }
        public int EffortStatAtk { get; set; }
        public int EffortStatDef { get; set; }
        public int EffortStatAtkSpe { get; set; }
        public int EffortStatDefSpe { get; set; }
        public int EffortStatSpd { get; set; }
        public int? PokedexNumberRegional { get; set; }
        public int Exp50 { get; set; }
        public int Exp100 { get; set; }

        public int HatchSteps
            => (HatchCounter + 1)*255;

        public string HeightFormated
            => PokemonBusiness.FormatHeight(Height);

        public string WeightFormated
            => PokemonBusiness.FormatWeight(Weight);

        public override string ToString()
        {
            return $"NameFr: {NameFr}";
        }
    }
}