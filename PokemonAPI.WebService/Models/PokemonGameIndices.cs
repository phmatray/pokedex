namespace PokemonAPI.WebService.Models
{
    public partial class PokemonGameIndices
    {
        public int PokemonId { get; set; }
        public int VersionId { get; set; }
        public int GameIndex { get; set; }

        public virtual Pokemon Pokemon { get; set; }
        public virtual Versions Version { get; set; }
    }
}
