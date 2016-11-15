using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestMaxLinks : IEFModel
    {
        public int WarriorRankId { get; set; }
        public int PokemonSpeciesId { get; set; }
        public int MaxLink { get; set; }

        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
        public virtual EFConquestWarriorRanks WarriorRank { get; set; }
    }
}
