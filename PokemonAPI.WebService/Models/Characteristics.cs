using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public partial class EFCharacteristics : IEFModel
    {
        public EFCharacteristics()
        {
            CharacteristicText = new HashSet<EFCharacteristicText>();
        }

        public int Id { get; set; }
        public int StatId { get; set; }
        public int GeneMod5 { get; set; }

        public virtual ICollection<EFCharacteristicText> CharacteristicText { get; set; }
        public virtual EFStats Stat { get; set; }
    }
}
