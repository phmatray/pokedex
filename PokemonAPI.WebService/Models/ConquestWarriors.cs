using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriors
    {
        public ConquestWarriors()
        {
            ConquestEpisodeWarriors = new HashSet<ConquestEpisodeWarriors>();
            ConquestTransformationWarriors = new HashSet<ConquestTransformationWarriors>();
            ConquestWarriorNames = new HashSet<ConquestWarriorNames>();
            ConquestWarriorRanks = new HashSet<ConquestWarriorRanks>();
            ConquestWarriorSpecialties = new HashSet<ConquestWarriorSpecialties>();
            ConquestWarriorTransformation = new HashSet<ConquestWarriorTransformation>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenderId { get; set; }
        public int? ArchetypeId { get; set; }

        public virtual ICollection<ConquestEpisodeWarriors> ConquestEpisodeWarriors { get; set; }
        public virtual ICollection<ConquestTransformationWarriors> ConquestTransformationWarriors { get; set; }
        public virtual ICollection<ConquestWarriorNames> ConquestWarriorNames { get; set; }
        public virtual ICollection<ConquestWarriorRanks> ConquestWarriorRanks { get; set; }
        public virtual ICollection<ConquestWarriorSpecialties> ConquestWarriorSpecialties { get; set; }
        public virtual ICollection<ConquestWarriorTransformation> ConquestWarriorTransformation { get; set; }
        public virtual ConquestWarriorArchetypes Archetype { get; set; }
        public virtual Genders Gender { get; set; }
    }
}
