using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveBattleStyles : IEFModel, IEFIdentifier
    {
        public EFMoveBattleStyles()
        {
            MoveBattleStyleProse = new HashSet<EFMoveBattleStyleProse>();
            NatureBattleStylePreferences = new HashSet<EFNatureBattleStylePreferences>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFMoveBattleStyleProse> MoveBattleStyleProse { get; set; }
        public virtual ICollection<EFNatureBattleStylePreferences> NatureBattleStylePreferences { get; set; }
    }
}
