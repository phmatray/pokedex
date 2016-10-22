using System;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Core
{
    internal static class APIResourceMapper
    {
        internal static APIResource ToApiResource(this IEFId id, string urlSegment)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrWhiteSpace(urlSegment))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlSegment));

            var url = $"{Constants.SiteUrl}{Constants.BaseUrl}{urlSegment}/{id.Id}/";
            return new APIResource(url);
        }

        internal static APIResource ToApiResource<TController>(this IEFId id)
            where TController: ApiController
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var url = $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(TController).Segment()}/{id.Id}/";
            return new APIResource(url);
        }

        internal static APIResource ToApiResource<TController>(this int id)
            where TController: ApiController
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var url = $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(TController).Segment()}/{id}/";
            return new APIResource(url);
        }

        internal static NamedAPIResource ToNamedApiResource(this IEFIdentifier identifier, string urlSegment)
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));
            if (string.IsNullOrWhiteSpace(urlSegment))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(urlSegment));
            
            var url = $"{Constants.SiteUrl}{Constants.BaseUrl}{urlSegment}/{identifier.Id}/";
            return new NamedAPIResource(identifier.Identifier, url);
        }

        internal static NamedAPIResource ToNamedApiResource<TController>(this IEFIdentifier identifier)
            where TController: ApiController
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));

            var url = $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(TController).Segment()}/{identifier.Id}/";
            return new NamedAPIResource(identifier.Identifier, url);
        }

        internal static NamedAPIResource ToNamedApiResource<TController>(this IEFIdentifier identifier, int id)
            where TController: ApiController
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var url = $"{Constants.SiteUrl}{Constants.BaseUrl}{typeof(TController).Segment()}/{id}/";
            return new NamedAPIResource(identifier.Identifier, url);
        }
    }
}