using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class MoveBattleStyles
    {
        public MoveBattleStyles()
        {
            MoveBattleStyleProse = new HashSet<MoveBattleStyleProse>();
            NatureBattleStylePreferences = new HashSet<NatureBattleStylePreferences>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<MoveBattleStyleProse> MoveBattleStyleProse { get; set; }
        public virtual ICollection<NatureBattleStylePreferences> NatureBattleStylePreferences { get; set; }
    }
}
