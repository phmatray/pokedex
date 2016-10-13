using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFEncounters : IEFModel
    {
        public EFEncounters()
        {
            EncounterConditionValueMap = new HashSet<EFEncounterConditionValueMap>();
        }

        public int Id { get; set; }
        public int VersionId { get; set; }
        public int LocationAreaId { get; set; }
        public int EncounterSlotId { get; set; }
        public int PokemonId { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }

        public virtual ICollection<EFEncounterConditionValueMap> EncounterConditionValueMap { get; set; }
        public virtual EFEncounterSlots EncounterSlot { get; set; }
        public virtual EFLocationAreas LocationArea { get; set; }
        public virtual EFPokemon Pokemon { get; set; }
        public virtual EFVersions Version { get; set; }
    }
}
