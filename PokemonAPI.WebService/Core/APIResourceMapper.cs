using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Core
{
    internal static class APIResourceMapper
    {
        internal static APIResource ToApiResource(this IEFId id)
        {
            var name = id.GetType().Name.ToLower();
            return new APIResource
            (
                $"{Constants.SiteUrl}{Constants.BaseUrl}{name}/{id.Id}/"
            );
        }

        internal static NamedAPIResource ToNamedApiResource(this IEFIdentifier identifier)
        {
            var name = identifier.GetType().Name.ToLower();
            return new NamedAPIResource
            (
                $"{Constants.SiteUrl}{Constants.BaseUrl}{name}/{identifier.Id}/",
                identifier.Identifier
            );
        }
    }
}