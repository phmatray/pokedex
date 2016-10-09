namespace PokedexG.Uwp.Models
{
    public class PokemonLite
    {
        public int PokemonId { get; set; }
        public int SpecieId { get; set; }
        public string FormIdentifier { get; set; }
        public string Name { get; set; }

        public string FormKey
            => FormIdentifier != null ? $"{SpecieId}-{FormIdentifier}" : $"{SpecieId}";

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}