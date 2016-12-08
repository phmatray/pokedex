using System.Collections.Generic;
using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public sealed class EFGenders : IEFIdentifier
    {
        public EFGenders()
        {
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
    }
}
