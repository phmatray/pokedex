using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class Characteristics
    {
        public Characteristics()
        {
            CharacteristicText = new HashSet<CharacteristicText>();
        }

        public int Id { get; set; }
        public int StatId { get; set; }
        public int GeneMod5 { get; set; }

        public virtual ICollection<CharacteristicText> CharacteristicText { get; set; }
        public virtual Stats Stat { get; set; }
    }
}
