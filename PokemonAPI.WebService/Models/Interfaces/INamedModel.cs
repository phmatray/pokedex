namespace PokemonAPI.WebService.Models.Interfaces
{
    public interface IName
    {
        string Name { get; set; }
        Languages LocalLanguage { get; set; }
    }

    public interface IGenus
    {
        string Genus { get; set; }
        Languages LocalLanguage { get; set; }
    }

    public interface IDescription
    {
        string Description { get; set; }
        Languages LocalLanguage { get; set; }
    }

    public interface IIdModel
    {
        int Id { get; set; }
    }

    public interface INamedModel
    {
        int Id { get; set; }
        string Identifier { get; set; }
    }
}