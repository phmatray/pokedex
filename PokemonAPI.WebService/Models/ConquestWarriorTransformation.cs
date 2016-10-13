using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestWarriorTransformation : IEFModel
    {
        public EFConquestWarriorTransformation()
        {
            ConquestTransformationPokemon = new HashSet<EFConquestTransformationPokemon>();
            ConquestTransformationWarriors = new HashSet<EFConquestTransformationWarriors>();
        }

        public int TransformedWarriorRankId { get; set; }
        public bool IsAutomatic { get; set; }
        public int? RequiredLink { get; set; }
        public int? CompletedEpisodeId { get; set; }
        public int? CurrentEpisodeId { get; set; }
        public int? DistantWarriorId { get; set; }
        public int? FemaleWarlordCount { get; set; }
        public int? PokemonCount { get; set; }
        public int? CollectionTypeId { get; set; }
        public int? WarriorCount { get; set; }

        public virtual ICollection<EFConquestTransformationPokemon> ConquestTransformationPokemon { get; set; }
        public virtual ICollection<EFConquestTransformationWarriors> ConquestTransformationWarriors { get; set; }
        public virtual EFTypes CollectionType { get; set; }
        public virtual EFConquestEpisodes CompletedEpisode { get; set; }
        public virtual EFConquestEpisodes CurrentEpisode { get; set; }
        public virtual EFConquestWarriors DistantWarrior { get; set; }
        public virtual EFConquestWarriorRanks TransformedWarriorRank { get; set; }
    }
}
