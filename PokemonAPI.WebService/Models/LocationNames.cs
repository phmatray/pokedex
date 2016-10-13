using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFLocationNames : IEFModel
    {
        public int LocationId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFLocations Location { get; set; }
    }
}
