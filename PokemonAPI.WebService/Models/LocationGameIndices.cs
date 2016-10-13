using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFLocationGameIndices : IEFModel
    {
        public int LocationId { get; set; }
        public int GenerationId { get; set; }
        public int GameIndex { get; set; }

        public virtual EFGenerations Generation { get; set; }
        public virtual EFLocations Location { get; set; }
    }
}
