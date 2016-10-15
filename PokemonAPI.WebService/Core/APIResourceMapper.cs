using System;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Core
{
    internal static class APIResourceMapper
    {
        internal static APIResource ToApiResource(this IEFId id, string segment)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return new APIResource
            (
                $"{Constants.SiteUrl}{Constants.BaseUrl}{segment}/{id.Id}/"
            );
        }

        internal static NamedAPIResource ToNamedApiResource(this IEFIdentifier identifier, string segment = null)
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));

            var url = segment == null 
                ? "NOT IMPLEMENTED"
                : $"{Constants.SiteUrl}{Constants.BaseUrl}{segment}/{identifier.Id}/";

            return new NamedAPIResource (identifier.Identifier, url);
        }
    }
}