using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorTransformation
    {
        public ConquestWarriorTransformation()
        {
            ConquestTransformationPokemon = new HashSet<ConquestTransformationPokemon>();
            ConquestTransformationWarriors = new HashSet<ConquestTransformationWarriors>();
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

        public virtual ICollection<ConquestTransformationPokemon> ConquestTransformationPokemon { get; set; }
        public virtual ICollection<ConquestTransformationWarriors> ConquestTransformationWarriors { get; set; }
        public virtual Types CollectionType { get; set; }
        public virtual ConquestEpisodes CompletedEpisode { get; set; }
        public virtual ConquestEpisodes CurrentEpisode { get; set; }
        public virtual ConquestWarriors DistantWarrior { get; set; }
        public virtual ConquestWarriorRanks TransformedWarriorRank { get; set; }
    }
}
