namespace PokemonAPI.WebService.Models
{
    public partial class VersionGroupRegions
    {
        public int VersionGroupId { get; set; }
        public int RegionId { get; set; }

        public virtual Regions Region { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
