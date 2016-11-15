namespace PokemonAPI.Models.Rsc
{
    public class NamedAPIResource : APIResource
    {
        public NamedAPIResource(int id, string name)
            : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// The name of the referenced resource
        /// </summary>
        public string Name { get; set; }
    }
}