using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFNatureNames : IEFModel
    {
        public int NatureId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFNatures Nature { get; set; }
    }
}
