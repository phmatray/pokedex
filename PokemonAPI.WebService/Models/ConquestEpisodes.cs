using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestEpisodes : IEFModel, IEFIdentifier
    {
        public EFConquestEpisodes()
        {
            ConquestEpisodeNames = new HashSet<EFConquestEpisodeNames>();
            ConquestEpisodeWarriors = new HashSet<EFConquestEpisodeWarriors>();
            ConquestWarriorTransformationCompletedEpisode = new HashSet<EFConquestWarriorTransformation>();
            ConquestWarriorTransformationCurrentEpisode = new HashSet<EFConquestWarriorTransformation>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFConquestEpisodeNames> ConquestEpisodeNames { get; set; }
        public virtual ICollection<EFConquestEpisodeWarriors> ConquestEpisodeWarriors { get; set; }
        public virtual ICollection<EFConquestWarriorTransformation> ConquestWarriorTransformationCompletedEpisode { get; set; }
        public virtual ICollection<EFConquestWarriorTransformation> ConquestWarriorTransformationCurrentEpisode { get; set; }
    }
}
