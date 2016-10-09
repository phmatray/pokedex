namespace PokemonAPI.WebService.Models
{
    public partial class TypeGameIndices
    {
        public int TypeId { get; set; }
        public int GenerationId { get; set; }
        public int GameIndex { get; set; }

        public virtual Generations Generation { get; set; }
        public virtual Types Type { get; set; }
    }
}
