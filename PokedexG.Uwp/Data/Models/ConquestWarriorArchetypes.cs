using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFConquestWarriorArchetypes : IEFIdentifier
    {
        public EFConquestWarriorArchetypes()
        {
            ConquestWarriors = new HashSet<EFConquestWarriors>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFConquestWarriors> ConquestWarriors { get; set; }
    }
}
