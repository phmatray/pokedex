namespace PokemonAPI.WebService.Models
{
    public partial class Machines
    {
        public int MachineNumber { get; set; }
        public int VersionGroupId { get; set; }
        public int ItemId { get; set; }
        public int MoveId { get; set; }

        public virtual Items Item { get; set; }
        public virtual Moves Move { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
