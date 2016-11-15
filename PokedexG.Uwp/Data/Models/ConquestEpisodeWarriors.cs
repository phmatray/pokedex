using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestEpisodeWarriors : IEFModel
    {
        public int EpisodeId { get; set; }
        public int WarriorId { get; set; }

        public virtual EFConquestEpisodes Episode { get; set; }
        public virtual EFConquestWarriors Warrior { get; set; }
    }
}
