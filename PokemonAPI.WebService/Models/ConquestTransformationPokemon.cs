namespace PokemonAPI.WebService.Models
{
    public partial class ConquestTransformationPokemon
    {
        public int TransformationId { get; set; }
        public int PokemonSpeciesId { get; set; }

        public virtual PokemonSpecies PokemonSpecies { get; set; }
        public virtual ConquestWarriorTransformation Transformation { get; set; }
    }
}
