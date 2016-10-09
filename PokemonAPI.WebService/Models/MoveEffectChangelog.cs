using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class MoveEffectChangelog
    {
        public MoveEffectChangelog()
        {
            MoveEffectChangelogProse = new HashSet<MoveEffectChangelogProse>();
        }

        public int Id { get; set; }
        public int EffectId { get; set; }
        public int ChangedInVersionGroupId { get; set; }

        public virtual ICollection<MoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public virtual VersionGroups ChangedInVersionGroup { get; set; }
        public virtual MoveEffects Effect { get; set; }
    }
}
