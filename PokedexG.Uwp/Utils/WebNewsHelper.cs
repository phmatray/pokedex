// http://www.actulligence.com/2014/10/10/google-news-et-les-rss/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Services.Bing;

namespace PokedexG.Uwp.Utils
{
    public static class WebNewsHelper
    {
        public static async Task<List<BingResult>> GetBingPokemonSearch()
        {
            var bingSearchConfig = new BingSearchConfig
            {
                Language = BingLanguage.French,
                Country = BingCountry.France,
                QueryType = BingQueryType.News,
                Query = "Pokémon"
            };

            var bingPokemonSearch = (await BingService.Instance.RequestAsync(bingSearchConfig, 50))
                .Select(x => new BingResult()
                {
                    InternalID = x.InternalID,
                    Published = x.Published,
                    Title = x.Title,
                    Summary = x.Summary,
                    Link = ExtractUrl(x.Link)
                })
                .ToList();

            return bingPokemonSearch;
        }

        private static string ExtractUrl(string link)
        {
            try
            {
                var url = link.Split(new[] { "&url=", "&c=" }, StringSplitOptions.None)[1];
                return link;
            }
            catch (Exception ex)
            {
                return link;
            }
        }
    }
}