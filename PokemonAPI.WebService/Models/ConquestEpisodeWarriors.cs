namespace PokemonAPI.WebService.Models
{
    public partial class ConquestEpisodeWarriors
    {
        public int EpisodeId { get; set; }
        public int WarriorId { get; set; }

        public virtual ConquestEpisodes Episode { get; set; }
        public virtual ConquestWarriors Warrior { get; set; }
    }
}
