namespace PokemonAPI.Models.Resources
{
    public class NamedAPIResource : APIResourceBase, IIdentifier
    {
        /// <summary>
        /// The name of the referenced resource
        /// </summary>
        public string Identifier { get; set; }
    }
}