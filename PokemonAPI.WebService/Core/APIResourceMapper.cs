using System;
using PokemonAPI.Models.Rsc;
using PokemonAPI.Models.SourceTypeEnums;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Core
{
    internal static class APIResourceMapper
    {
        internal static APIResource ToApiResource(this IEFId id)
        {
            var name = id.GetType().Name.ToLower();
            return new APIResource
            {
                Url = $"{Constants.SiteUrl}{Constants.BaseUrl}{name}/{id.Id}/",
            };
        }

        internal static NamedAPIResource ToNamedApiResource(this IEFIdentifier identifier)
        {
            var name = identifier.GetType().Name.ToLower();
            return new NamedAPIResource
            {
                Url = $"{Constants.SiteUrl}{Constants.BaseUrl}{name}/{identifier.Id}/",
                Name = identifier.Identifier
            };
        }

        internal static NamedAPIResource ToNamedApiResource(this EFVersionGroupPokemonMoveMethods moveMethod)
        {
            return new NamedAPIResource
            {
                Url = $"{Constants.SiteUrl}{Constants.BaseUrl}movemethods/{moveMethod.PokemonMoveMethodId}/",
                Name = moveMethod.PokemonMoveMethod.Identifier
            };
        }

        internal static NamedAPIResource ToNamedApiResource(this EFVersionGroupRegions source,
            VersionGroupRegionSourceType sourceType)
        {
            switch (sourceType)
            {
                case VersionGroupRegionSourceType.VersionGroup:
                    return new NamedAPIResource
                    {
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}regions/{source.RegionId}/",
                        Name = source.Region.Identifier
                    };
                case VersionGroupRegionSourceType.Region:
                    return new NamedAPIResource
                    {
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}versiongroups/{source.VersionGroupId}/",
                        Name = source.VersionGroup.Identifier
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null);
            }
        }

        internal static NamedAPIResource ToNamedApiResource(this EFPokedexVersionGroups source,
            PokedexVersionGroupsSourceType sourceType)
        {
            switch (sourceType)
            {
                case PokedexVersionGroupsSourceType.Pokedex:
                    return new NamedAPIResource
                    {
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}versiongroups/{source.VersionGroupId}/",
                        Name = source.VersionGroup.Identifier
                    };
                case PokedexVersionGroupsSourceType.VersionGroup:
                    return new NamedAPIResource
                    {
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}pokedexes/{source.PokedexId}/",
                        Name = source.Pokedex.Identifier
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null);
            }
        }

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonEggGroups source,
            PokemonEggGroupsSourceType sourceType)
        {
            switch (sourceType)
            {
                case PokemonEggGroupsSourceType.Species:
                    return new NamedAPIResource
                    {
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}egggroups/{source.EggGroupId}/",
                        Name = source.EggGroup.Identifier
                    };
                case PokemonEggGroupsSourceType.EggGroup:
                    return new NamedAPIResource
                    {
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}pokemonspecies/{source.SpeciesId}/",
                        Name = source.Species.Identifier
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null);
            }
        }

        internal static PalParkEncounterArea ToPalParkEncounterAreaResource(this EFPalPark source)
        {
            return new PalParkEncounterArea
            {
                BaseScore = source.BaseScore,
                Rate = source.Rate,
                Area = source.Area.ToNamedApiResource()
            };
        }

        internal static FlavorText ToFlavorTextResource(this EFPokemonSpeciesFlavorText source)
        {
            return new FlavorText
            {
                FlavorTextValue = source.FlavorText,
                Version = source.Version.ToNamedApiResource(),
                Language = source.Language.ToNamedApiResource()
            };
        }

        internal static PokemonSpeciesDexEntry ToPokemonSpeciesDexEntryResource(this EFPokemonDexNumbers source)
        {
            return new PokemonSpeciesDexEntry
            {
                EntryNumber = source.PokedexNumber,
                Pokedex = source.Pokedex.ToNamedApiResource()
            };
        }

        internal static PokemonEntry ToPokemonEntryResource(this EFPokemonDexNumbers source)
        {
            return new PokemonEntry
            {
                EntryNumber = source.PokedexNumber,
                PokemonSpecies = source.Species.ToNamedApiResource()
            };
        }

        //internal static Name ToNameResource(this IName name)
        //{
        //    return new Name
        //    {
        //        NameValue = name.Name,
        //        Language = name.LocalLanguage.ToNamedApiResource()
        //    };
        //}

        //internal static Genus ToGenusResource(this IGenus genus)
        //{
        //    return new Genus
        //    {
        //        GenusValue = genus.Genus,
        //        Language = genus.LocalLanguage.ToNamedApiResource()
        //    };
        //}

        internal static PokemonSpeciesVariety ToPokemonSpeciesVarietyResource(this EFPokemon pokemon)
        {
            return new PokemonSpeciesVariety
            {
                IsDefault = pokemon.IsDefault,
                Pokemon = pokemon.ToNamedApiResource()
            };
        }

        #region DescriptionResource

        //internal static Description ToDescriptionResource(this IDescription description)
        //{
        //    return new Description
        //    {
        //        DescriptionValue = description.Description,
        //        Language = description.LocalLanguage.ToNamedApiResource()
        //    };
        //}

        //internal static Description ToDescriptionResource(this EFPokemonSpeciesFlavorSummaries source)
        //{
        //    return new Description
        //    {
        //        DescriptionValue = source.FlavorSummary,
        //        Language = source.LocalLanguage.ToNamedApiResource()
        //    };
        //}

        //internal static Description ToDescriptionResource(this EFGrowthRateProse source)
        //{
        //    return new Description
        //    {
        //        DescriptionValue = source.Name,
        //        Language = source.LocalLanguage.ToNamedApiResource()
        //    };
        //}

        #endregion

        #region Experience

        internal static GrowthRateExperienceLevel ToGrowthRateExperienceLevelResource(this EFExperience source)
        {
            return new GrowthRateExperienceLevel
            {
                Experience = source.Experience1,
                Level = source.Level
            };
        }

        #endregion
    }
}