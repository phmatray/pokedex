namespace PokemonAPI.WebService.Models
{
    public partial class ConquestPokemonAbilities
    {
        public int PokemonSpeciesId { get; set; }
        public int Slot { get; set; }
        public int AbilityId { get; set; }

        public virtual Abilities Ability { get; set; }
        public virtual PokemonSpecies PokemonSpecies { get; set; }
    }
}
