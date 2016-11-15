using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestTransformationPokemon : IEFModel
    {
        public int TransformationId { get; set; }
        public int PokemonSpeciesId { get; set; }

        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
        public virtual EFConquestWarriorTransformation Transformation { get; set; }
    }
}
