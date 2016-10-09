using System.Collections.Generic;

namespace PokemonAPI.WebService.Models
{
    public partial class ItemFlags
    {
        public ItemFlags()
        {
            ItemFlagMap = new HashSet<ItemFlagMap>();
            ItemFlagProse = new HashSet<ItemFlagProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<ItemFlagMap> ItemFlagMap { get; set; }
        public virtual ICollection<ItemFlagProse> ItemFlagProse { get; set; }
    }
}
