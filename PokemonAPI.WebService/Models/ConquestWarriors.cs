using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestWarriors : IEFModel, IEFIdentifier
    {
        public EFConquestWarriors()
        {
            ConquestEpisodeWarriors = new HashSet<EFConquestEpisodeWarriors>();
            ConquestTransformationWarriors = new HashSet<EFConquestTransformationWarriors>();
            ConquestWarriorNames = new HashSet<EFConquestWarriorNames>();
            ConquestWarriorRanks = new HashSet<EFConquestWarriorRanks>();
            ConquestWarriorSpecialties = new HashSet<EFConquestWarriorSpecialties>();
            ConquestWarriorTransformation = new HashSet<EFConquestWarriorTransformation>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenderId { get; set; }
        public int? ArchetypeId { get; set; }

        public virtual ICollection<EFConquestEpisodeWarriors> ConquestEpisodeWarriors { get; set; }
        public virtual ICollection<EFConquestTransformationWarriors> ConquestTransformationWarriors { get; set; }
        public virtual ICollection<EFConquestWarriorNames> ConquestWarriorNames { get; set; }
        public virtual ICollection<EFConquestWarriorRanks> ConquestWarriorRanks { get; set; }
        public virtual ICollection<EFConquestWarriorSpecialties> ConquestWarriorSpecialties { get; set; }
        public virtual ICollection<EFConquestWarriorTransformation> ConquestWarriorTransformation { get; set; }
        public virtual EFConquestWarriorArchetypes Archetype { get; set; }
        public virtual EFGenders Gender { get; set; }
    }
}
