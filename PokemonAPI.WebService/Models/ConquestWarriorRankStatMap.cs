namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorRankStatMap
    {
        public int WarriorRankId { get; set; }
        public int WarriorStatId { get; set; }
        public int BaseStat { get; set; }

        public virtual ConquestWarriorRanks WarriorRank { get; set; }
        public virtual ConquestWarriorStats WarriorStat { get; set; }
    }
}
