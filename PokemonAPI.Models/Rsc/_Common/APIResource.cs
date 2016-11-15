namespace PokemonAPI.Models.Rsc
{
    public class APIResource
    {
        public APIResource(int id)
        {
            Id = id;
        }

        /// <summary>
        /// The ID of the referenced resource
        /// </summary>
        public int Id { get; set; }
    }
}