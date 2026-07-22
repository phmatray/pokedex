namespace PokedexG.Uwp.Models
{
    public class PokemonAbility
    {
        public int PokemonId { get; set; }
        public int AbilityId { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
        public string AbilityIdentifier { get; set; }
        public int GenerationId { get; set; }
        public string AbilityName { get; set; }
        public string FlavorText { get; set; }
    }
}