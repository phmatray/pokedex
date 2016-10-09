namespace PokemonAPI.WebService.Models
{
    public partial class ConquestTransformationWarriors
    {
        public int TransformationId { get; set; }
        public int PresentWarriorId { get; set; }

        public virtual ConquestWarriors PresentWarrior { get; set; }
        public virtual ConquestWarriorTransformation Transformation { get; set; }
    }
}
