using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFAbilities : IEFModel, IEFIdentifier
    {
        public EFAbilities()
        {
            AbilityChangelog = new HashSet<EFAbilityChangelog>();
            AbilityFlavorText = new HashSet<EFAbilityFlavorText>();
            AbilityNames = new HashSet<EFAbilityNames>();
            AbilityProse = new HashSet<EFAbilityProse>();
            ConquestPokemonAbilities = new HashSet<EFConquestPokemonAbilities>();
            PokemonAbilities = new HashSet<EFPokemonAbilities>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public bool IsMainSeries { get; set; }

        public virtual ICollection<EFAbilityChangelog> AbilityChangelog { get; set; }
        public virtual ICollection<EFAbilityFlavorText> AbilityFlavorText { get; set; }
        public virtual ICollection<EFAbilityNames> AbilityNames { get; set; }
        public virtual ICollection<EFAbilityProse> AbilityProse { get; set; }
        public virtual ICollection<EFConquestPokemonAbilities> ConquestPokemonAbilities { get; set; }
        public virtual ICollection<EFPokemonAbilities> PokemonAbilities { get; set; }
        public virtual EFGenerations Generation { get; set; }
    }
}
