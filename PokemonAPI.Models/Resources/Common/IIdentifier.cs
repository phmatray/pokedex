namespace PokemonAPI.Models.Resources
{
    public interface IIdentifier
    {
        int Id { get; set; }
        string Identifier { get; set; }
    }
}