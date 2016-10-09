using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestEpisodes
    {
        public ConquestEpisodes()
        {
            ConquestEpisodeNames = new HashSet<ConquestEpisodeNames>();
            ConquestEpisodeWarriors = new HashSet<ConquestEpisodeWarriors>();
            ConquestWarriorTransformationCompletedEpisode = new HashSet<ConquestWarriorTransformation>();
            ConquestWarriorTransformationCurrentEpisode = new HashSet<ConquestWarriorTransformation>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<ConquestEpisodeNames> ConquestEpisodeNames { get; set; }
        public virtual ICollection<ConquestEpisodeWarriors> ConquestEpisodeWarriors { get; set; }
        public virtual ICollection<ConquestWarriorTransformation> ConquestWarriorTransformationCompletedEpisode { get; set; }
        public virtual ICollection<ConquestWarriorTransformation> ConquestWarriorTransformationCurrentEpisode { get; set; }
    }
}
