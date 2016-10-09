namespace PokemonAPI.WebService.Models
{
    public partial class ConquestPokemonEvolution
    {
        public int EvolvedSpeciesId { get; set; }
        public int? RequiredStatId { get; set; }
        public int? MinimumStat { get; set; }
        public int? MinimumLink { get; set; }
        public int? KingdomId { get; set; }
        public int? WarriorGenderId { get; set; }
        public int? ItemId { get; set; }
        public bool RecruitingKoRequired { get; set; }

        public virtual PokemonSpecies EvolvedSpecies { get; set; }
        public virtual Items Item { get; set; }
        public virtual ConquestKingdoms Kingdom { get; set; }
        public virtual ConquestStats RequiredStat { get; set; }
        public virtual Genders WarriorGender { get; set; }
    }
}
