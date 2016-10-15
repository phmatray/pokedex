using System;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Core
{
    internal static class APIResourceMapper
    {
        internal static APIResource ToApiResource(this IEFId id, string urlSegment)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return new APIResource
            (
                $"{Constants.SiteUrl}{Constants.BaseUrl}{urlSegment}/{id.Id}/"
            );
        }

        internal static NamedAPIResource ToNamedApiResource(this IEFIdentifier identifier, string urlSegment)
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));
            if (string.IsNullOrWhiteSpace(urlSegment))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlSegment));
            
            var url = $"{Constants.SiteUrl}{Constants.BaseUrl}{urlSegment}/{identifier.Id}/";
            return new NamedAPIResource (identifier.Identifier, url);
        }
    }
}