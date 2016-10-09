using System;
using PokemonAPI.Models.Resources;
using PokemonAPI.Models.SourceTypeEnums;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Core
{
    internal static class APIResourceMapper
    {
        internal static APIResource ToApiResource(this IIdModel idModel)
        {
            var name = idModel.GetType().Name.ToLower();
            return new APIResource
            {
                Id = idModel.Id,
                Url = $"{Constants.SiteUrl}{Constants.BaseUrl}{name}/{idModel.Id}/",
            };
        }

        internal static NamedAPIResource ToNamedApiResource(this INamedModel namedModel)
        {
            var name = namedModel.GetType().Name.ToLower();
            return new NamedAPIResource
            {
                Id = namedModel.Id,
                Url = $"{Constants.SiteUrl}{Constants.BaseUrl}{name}/{namedModel.Id}/",
                Identifier = namedModel.Identifier
            };
        }

        internal static NamedAPIResource ToNamedApiResource(this VersionGroupPokemonMoveMethods moveMethod)
        {
            return new NamedAPIResource
            {
                Id = moveMethod.PokemonMoveMethodId,
                Url = $"{Constants.SiteUrl}{Constants.BaseUrl}movemethods/{moveMethod.PokemonMoveMethodId}/",
                Identifier = moveMethod.PokemonMoveMethod.Identifier
            };
        }

        internal static NamedAPIResource ToNamedApiResource(this VersionGroupRegions source,
            VersionGroupRegionSourceType sourceType)
        {
            switch (sourceType)
            {
                case VersionGroupRegionSourceType.VersionGroup:
                    return new NamedAPIResource
                    {
                        Id = source.RegionId,
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}regions/{source.RegionId}/",
                        Identifier = source.Region.Identifier
                    };
                case VersionGroupRegionSourceType.Region:
                    return new NamedAPIResource
                    {
                        Id = source.VersionGroupId,
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}versiongroups/{source.VersionGroupId}/",
                        Identifier = source.VersionGroup.Identifier
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null);
            }
        }

        internal static NamedAPIResource ToNamedApiResource(this PokedexVersionGroups source,
            PokedexVersionGroupsSourceType sourceType)
        {
            switch (sourceType)
            {
                case PokedexVersionGroupsSourceType.Pokedex:
                    return new NamedAPIResource
                    {
                        Id = source.VersionGroupId,
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}versiongroups/{source.VersionGroupId}/",
                        Identifier = source.VersionGroup.Identifier
                    };
                case PokedexVersionGroupsSourceType.VersionGroup:
                    return new NamedAPIResource
                    {
                        Id = source.PokedexId,
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}pokedexes/{source.PokedexId}/",
                        Identifier = source.Pokedex.Identifier
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null);
            }
        }

        internal static NamedAPIResource ToNamedApiResource(this PokemonEggGroups source,
            PokemonEggGroupsSourceType sourceType)
        {
            switch (sourceType)
            {
                case PokemonEggGroupsSourceType.Species:
                    return new NamedAPIResource
                    {
                        Id = source.EggGroupId,
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}egggroups/{source.EggGroupId}/",
                        Identifier = source.EggGroup.Identifier
                    };
                case PokemonEggGroupsSourceType.EggGroup:
                    return new NamedAPIResource
                    {
                        Id = source.SpeciesId,
                        Url = $"{Constants.SiteUrl}{Constants.BaseUrl}pokemonspecies/{source.SpeciesId}/",
                        Identifier = source.Species.Identifier
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(sourceType), sourceType, null);
            }
        }

        internal static PalParkEncounterAreaResource ToPalParkEncounterAreaResource(this PalPark source)
        {
            return new PalParkEncounterAreaResource
            {
                BaseScore = source.BaseScore,
                Rate = source.Rate,
                Area = source.Area.ToNamedApiResource()
            };
        }

        internal static FlavorTextResource ToFlavorTextResource(this PokemonSpeciesFlavorText source)
        {
            return new FlavorTextResource
            {
                FlavorText = source.FlavorText,
                Version = source.Version.ToNamedApiResource(),
                Language = source.Language.ToNamedApiResource()
            };
        }

        internal static PokemonSpeciesDexEntryResource ToPokemonSpeciesDexEntryResource(this PokemonDexNumbers source)
        {
            return new PokemonSpeciesDexEntryResource
            {
                EntryNumber = source.PokedexNumber,
                Pokedex = source.Pokedex.ToNamedApiResource()
            };
        }

        internal static PokemonEntryResource ToPokemonEntryResource(this PokemonDexNumbers source)
        {
            return new PokemonEntryResource
            {
                EntryNumber = source.PokedexNumber,
                PokemonSpecies = source.Species.ToNamedApiResource()
            };
        }

        internal static NameResource ToNameResource(this IName name)
        {
            return new NameResource
            {
                Name = name.Name,
                Language = name.LocalLanguage.ToNamedApiResource()
            };
        }

        internal static GenusResource ToGenusResource(this IGenus genus)
        {
            return new GenusResource
            {
                Genus = genus.Genus,
                Language = genus.LocalLanguage.ToNamedApiResource()
            };
        }

        internal static PokemonSpeciesVarietyResource ToPokemonSpeciesVarietyResource(this Pokemon pokemon)
        {
            return new PokemonSpeciesVarietyResource
            {
                IsDefault = pokemon.IsDefault,
                Pokemon = pokemon.ToNamedApiResource()
            };
        }

        #region DescriptionResource

        internal static DescriptionResource ToDescriptionResource(this IDescription description)
        {
            return new DescriptionResource
            {
                Description = description.Description,
                Language = description.LocalLanguage.ToNamedApiResource()
            };
        }

        internal static DescriptionResource ToDescriptionResource(this PokemonSpeciesFlavorSummaries source)
        {
            return new DescriptionResource
            {
                Description = source.FlavorSummary,
                Language = source.LocalLanguage.ToNamedApiResource()
            };
        }

        internal static DescriptionResource ToDescriptionResource(this GrowthRateProse source)
        {
            return new DescriptionResource
            {
                Description = source.Name,
                Language = source.LocalLanguage.ToNamedApiResource()
            };
        }

        #endregion

        #region Experience

        internal static GrowthRateExperienceLevelResource ToGrowthRateExperienceLevelResource(this Experience source)
        {
            return new GrowthRateExperienceLevelResource
            {
                Experience = source.Experience1,
                Level = source.Level
            };
        }

        #endregion
    }
}