using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class AbilityChangelog
    {
        public AbilityChangelog()
        {
            AbilityChangelogProse = new HashSet<AbilityChangelogProse>();
        }

        public int Id { get; set; }
        public int AbilityId { get; set; }
        public int ChangedInVersionGroupId { get; set; }

        public virtual ICollection<AbilityChangelogProse> AbilityChangelogProse { get; set; }
        public virtual Abilities Ability { get; set; }
        public virtual VersionGroups ChangedInVersionGroup { get; set; }
    }
}
