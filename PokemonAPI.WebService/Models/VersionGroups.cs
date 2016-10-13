using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFVersionGroups : IEFModel, IEFIdentifier
    {
        public EFVersionGroups()
        {
            AbilityChangelog = new HashSet<EFAbilityChangelog>();
            AbilityFlavorText = new HashSet<EFAbilityFlavorText>();
            EncounterSlots = new HashSet<EFEncounterSlots>();
            ItemFlavorText = new HashSet<EFItemFlavorText>();
            Machines = new HashSet<EFMachines>();
            MoveChangelog = new HashSet<EFMoveChangelog>();
            MoveEffectChangelog = new HashSet<EFMoveEffectChangelog>();
            MoveFlavorText = new HashSet<EFMoveFlavorText>();
            PokedexVersionGroups = new HashSet<EFPokedexVersionGroups>();
            PokemonForms = new HashSet<EFPokemonForms>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            VersionGroupPokemonMoveMethods = new HashSet<EFVersionGroupPokemonMoveMethods>();
            VersionGroupRegions = new HashSet<EFVersionGroupRegions>();
            Versions = new HashSet<EFVersions>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public int? Order { get; set; }

        public virtual ICollection<EFAbilityChangelog> AbilityChangelog { get; set; }
        public virtual ICollection<EFAbilityFlavorText> AbilityFlavorText { get; set; }
        public virtual ICollection<EFEncounterSlots> EncounterSlots { get; set; }
        public virtual ICollection<EFItemFlavorText> ItemFlavorText { get; set; }
        public virtual ICollection<EFMachines> Machines { get; set; }
        public virtual ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public virtual ICollection<EFMoveEffectChangelog> MoveEffectChangelog { get; set; }
        public virtual ICollection<EFMoveFlavorText> MoveFlavorText { get; set; }
        public virtual ICollection<EFPokedexVersionGroups> PokedexVersionGroups { get; set; }
        public virtual ICollection<EFPokemonForms> PokemonForms { get; set; }
        public virtual ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public virtual ICollection<EFVersionGroupPokemonMoveMethods> VersionGroupPokemonMoveMethods { get; set; }
        public virtual ICollection<EFVersionGroupRegions> VersionGroupRegions { get; set; }
        public virtual ICollection<EFVersions> Versions { get; set; }
        public virtual EFGenerations Generation { get; set; }
    }
}
