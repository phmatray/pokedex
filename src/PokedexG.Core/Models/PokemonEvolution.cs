namespace PokedexG.Uwp.Models
{
    public class PokemonEvolution
    {
        public int PokemonId { get; set; }
        public string PokemonIdentifier { get; set; }
        public int GenerationId { get; set; }
        public int? EvolvesFromSpeciesId { get; set; }
        public int EvolutionChainId { get; set; }
        public bool IsBaby { get; set; }
        public bool IsMega { get; set; }
        public string NameFr { get; set; }

        public override string ToString()
        {
            return $"{nameof(NameFr)}: {NameFr}";
        }
    }
}