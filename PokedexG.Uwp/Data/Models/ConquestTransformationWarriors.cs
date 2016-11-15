using PokedexG.Uwp.Data.Models.Interfaces;

namespace PokedexG.Uwp.Data.Models
{
    public class EFConquestTransformationWarriors : IEFModel
    {
        public int TransformationId { get; set; }
        public int PresentWarriorId { get; set; }

        public virtual EFConquestWarriors PresentWarrior { get; set; }
        public virtual EFConquestWarriorTransformation Transformation { get; set; }
    }
}
