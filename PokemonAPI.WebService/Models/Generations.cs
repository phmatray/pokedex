using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFGenerations : IEFModel, IEFIdentifier
    {
        public EFGenerations()
        {
            Abilities = new HashSet<EFAbilities>();
            GenerationNames = new HashSet<EFGenerationNames>();
            ItemGameIndices = new HashSet<EFItemGameIndices>();
            LocationGameIndices = new HashSet<EFLocationGameIndices>();
            Moves = new HashSet<EFMoves>();
            PokemonFormGenerations = new HashSet<EFPokemonFormGenerations>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
            TypeGameIndices = new HashSet<EFTypeGameIndices>();
            Types = new HashSet<EFTypes>();
            VersionGroups = new HashSet<EFVersionGroups>();
        }

        public int Id { get; set; }
        public int MainRegionId { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFAbilities> Abilities { get; set; }
        public virtual ICollection<EFGenerationNames> GenerationNames { get; set; }
        public virtual ICollection<EFItemGameIndices> ItemGameIndices { get; set; }
        public virtual ICollection<EFLocationGameIndices> LocationGameIndices { get; set; }
        public virtual ICollection<EFMoves> Moves { get; set; }
        public virtual ICollection<EFPokemonFormGenerations> PokemonFormGenerations { get; set; }
        public virtual ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
        public virtual ICollection<EFTypeGameIndices> TypeGameIndices { get; set; }
        public virtual ICollection<EFTypes> Types { get; set; }
        public virtual ICollection<EFVersionGroups> VersionGroups { get; set; }
        public virtual EFRegions MainRegion { get; set; }
    }
}
