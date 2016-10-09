namespace PokemonAPI.WebService.Models
{
    public partial class MoveDamageClassProse
    {
        public int MoveDamageClassId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Languages LocalLanguage { get; set; }
        public virtual MoveDamageClasses MoveDamageClass { get; set; }
    }
}
