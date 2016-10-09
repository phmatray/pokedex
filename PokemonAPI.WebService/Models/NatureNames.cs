namespace PokemonAPI.WebService.Models
{
    public partial class NatureNames
    {
        public int NatureId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual Natures Nature { get; set; }
    }
}
