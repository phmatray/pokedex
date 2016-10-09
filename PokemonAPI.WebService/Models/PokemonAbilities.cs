namespace PokemonAPI.WebService.Models
{
    public partial class PokemonAbilities
    {
        public int PokemonId { get; set; }
        public int AbilityId { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }

        public virtual Abilities Ability { get; set; }
        public virtual Pokemon Pokemon { get; set; }
    }
}
