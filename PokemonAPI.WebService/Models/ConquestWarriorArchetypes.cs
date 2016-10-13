using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestWarriorArchetypes : IEFModel, IEFIdentifier
    {
        public EFConquestWarriorArchetypes()
        {
            ConquestWarriors = new HashSet<EFConquestWarriors>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFConquestWarriors> ConquestWarriors { get; set; }
    }
}
