namespace PokemonAPI.WebService.Models
{
    public partial class VersionGroupPokemonMoveMethods
    {
        public int VersionGroupId { get; set; }
        public int PokemonMoveMethodId { get; set; }

        public virtual PokemonMoveMethods PokemonMoveMethod { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
