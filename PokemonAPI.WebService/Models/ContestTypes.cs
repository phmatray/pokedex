using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ContestTypes
    {
        public ContestTypes()
        {
            BerryFlavors = new HashSet<BerryFlavors>();
            ContestTypeNames = new HashSet<ContestTypeNames>();
            Moves = new HashSet<Moves>();
            NaturesHatesFlavor = new HashSet<Natures>();
            NaturesLikesFlavor = new HashSet<Natures>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<BerryFlavors> BerryFlavors { get; set; }
        public virtual ICollection<ContestTypeNames> ContestTypeNames { get; set; }
        public virtual ICollection<Moves> Moves { get; set; }
        public virtual ICollection<Natures> NaturesHatesFlavor { get; set; }
        public virtual ICollection<Natures> NaturesLikesFlavor { get; set; }
    }
}
