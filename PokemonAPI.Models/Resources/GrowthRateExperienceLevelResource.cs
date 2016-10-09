namespace PokemonAPI.Models.Resources
{
    public class GrowthRateExperienceLevelResource
    {
        /// <summary>
        /// The level gained
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The amount of experience required to reach the referenced level
        /// </summary>
        public int Experience { get; set; }
    }
}