namespace PokemonAPI.WebService.Models
{
    public partial class CharacteristicText
    {
        public int CharacteristicId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Message { get; set; }

        public virtual Characteristics Characteristic { get; set; }
        public virtual Languages LocalLanguage { get; set; }
    }
}
