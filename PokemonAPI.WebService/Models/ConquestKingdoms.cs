using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFConquestKingdoms : IEFModel, IEFIdentifier
    {
        public EFConquestKingdoms()
        {
            ConquestKingdomNames = new HashSet<EFConquestKingdomNames>();
            ConquestPokemonEvolution = new HashSet<EFConquestPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int TypeId { get; set; }

        public virtual ICollection<EFConquestKingdomNames> ConquestKingdomNames { get; set; }
        public virtual ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public virtual EFTypes Type { get; set; }
    }
}
