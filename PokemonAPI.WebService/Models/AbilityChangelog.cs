using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFAbilityChangelog : IEFModel
    {
        public EFAbilityChangelog()
        {
            AbilityChangelogProse = new HashSet<EFAbilityChangelogProse>();
        }

        public int Id { get; set; }
        public int AbilityId { get; set; }
        public int ChangedInVersionGroupId { get; set; }

        public virtual ICollection<EFAbilityChangelogProse> AbilityChangelogProse { get; set; }
        public virtual EFAbilities Ability { get; set; }
        public virtual EFVersionGroups ChangedInVersionGroup { get; set; }
    }
}
