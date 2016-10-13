using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFContestTypes : IEFModel, IEFIdentifier
    {
        public EFContestTypes()
        {
            BerryFlavors = new HashSet<EFBerryFlavors>();
            ContestTypeNames = new HashSet<EFContestTypeNames>();
            Moves = new HashSet<EFMoves>();
            NaturesHatesFlavor = new HashSet<EFNatures>();
            NaturesLikesFlavor = new HashSet<EFNatures>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<EFBerryFlavors> BerryFlavors { get; set; }
        public virtual ICollection<EFContestTypeNames> ContestTypeNames { get; set; }
        public virtual ICollection<EFMoves> Moves { get; set; }
        public virtual ICollection<EFNatures> NaturesHatesFlavor { get; set; }
        public virtual ICollection<EFNatures> NaturesLikesFlavor { get; set; }
    }
}
