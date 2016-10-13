using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFMoveEffectChangelog : IEFModel
    {
        public EFMoveEffectChangelog()
        {
            MoveEffectChangelogProse = new HashSet<EFMoveEffectChangelogProse>();
        }

        public int Id { get; set; }
        public int EffectId { get; set; }
        public int ChangedInVersionGroupId { get; set; }

        public virtual ICollection<EFMoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public virtual EFVersionGroups ChangedInVersionGroup { get; set; }
        public virtual EFMoveEffects Effect { get; set; }
    }
}
