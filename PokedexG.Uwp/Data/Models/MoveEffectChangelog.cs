using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFMoveEffectChangelog : IEFModel
    {
        public EFMoveEffectChangelog()
        {
            MoveEffectChangelogProse = new HashSet<EFMoveEffectChangelogProse>();
        }

        public int Id { get; set; }
        public int EffectId { get; set; }
        public int ChangedInVersionGroupId { get; set; }

        public ICollection<EFMoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public EFVersionGroups ChangedInVersionGroup { get; set; }
        public EFMoveEffects Effect { get; set; }
    }
}
