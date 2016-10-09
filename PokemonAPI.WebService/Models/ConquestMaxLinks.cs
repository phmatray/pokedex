namespace PokemonAPI.WebService.Models
{
    public partial class ConquestMaxLinks
    {
        public int WarriorRankId { get; set; }
        public int PokemonSpeciesId { get; set; }
        public int MaxLink { get; set; }

        public virtual PokemonSpecies PokemonSpecies { get; set; }
        public virtual ConquestWarriorRanks WarriorRank { get; set; }
    }
}
