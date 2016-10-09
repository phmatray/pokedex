using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ConquestWarriorArchetypes
    {
        public ConquestWarriorArchetypes()
        {
            ConquestWarriors = new HashSet<ConquestWarriors>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<ConquestWarriors> ConquestWarriors { get; set; }
    }
}
