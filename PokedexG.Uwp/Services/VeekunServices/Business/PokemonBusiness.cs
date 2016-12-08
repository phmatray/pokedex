using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Utils;

namespace PokedexG.Uwp.Services.VeekunServices.Business
{
    public static class PokemonBusiness
    {
        public static string CleanMarkdown(this string s)
        {
            const string pattern = @"\[[\w- ]*\]{[\w:-]*}";
            var matches = Regex.Matches(s, pattern);
            foreach (Match match in matches)
            {
                var matchValue = match.Value;
                var replacementValue = Regex.Match(match.Value, @"\[[\w- ]*\]").Value.Trim('[', ']');

                if (replacementValue == "")
                    replacementValue = matchValue.Split(':').Last().TrimEnd('}');

                s = s.Replace(matchValue, replacementValue);
            }

            return s;
        }



        public static List<DamageTypeUiModel> GetWeaknesses(
            List<DamageTypeUiModel> type1DamageFrom, List<DamageTypeUiModel> type2DamageFrom, bool excludeNeutral = false)
        {
            var types = new List<DamageTypeUiModel>()
                .Concat(type1DamageFrom)
                .Concat(type2DamageFrom)
                .ToList();

            var weaknesses = types
                .GroupBy(x => x.DamageTypeId)
                .Select(g =>
                {
                    var damageType = g.First();
                    var damageTypeUiModels = g.ToList();

                    damageType.DamageFactor = damageTypeUiModels.Count == 2
                        ? (int) ((double) (damageTypeUiModels[0].DamageFactor*damageTypeUiModels[1].DamageFactor)/100)
                        : -1;

                    return damageType;
                })
                .OrderByDescending(x => x.DamageFactor)
                .ToList();

            if (excludeNeutral)
            {
                weaknesses = weaknesses
                    .Where(x => x.DamageFactor != 100)
                    .ToList();
            }

            return weaknesses;
        }

        public static async Task<List<DamageType>> GetWeaknessesAsync(int type1Id, int type2Id, bool excludeNeutral = false)
        {
            if (type1Id <= 0) throw new ArgumentOutOfRangeException(nameof(type1Id));
            if (type2Id < 0) throw new ArgumentOutOfRangeException(nameof(type2Id));

            var typeRelations = await Veekun.GetTypeRelationsAsync();
            var weaknesses = typeRelations
                .Where(x => x.TargetTypeId == type1Id || x.TargetTypeId == type2Id)
                .GroupBy(x => x.DamageTypeId)
                .Select(g =>
                {
                    var damageFactor = 0;
                    switch (g.Count())
                    {
                        case 1:
                            damageFactor = g.ToList()[0].DamageFactor;
                            break;
                        case 2:
                            damageFactor = (int)((double)(g.ToList()[0].DamageFactor * g.ToList()[1].DamageFactor) / 100);
                            break;
                    }

                    var firstTypeRelation = g.First();
                    return new DamageType
                    {
                        DamageTypeId = firstTypeRelation.DamageTypeId,
                        DamageTypeIdentifier = firstTypeRelation.DamageTypeIdentifier,
                        DamageTypeName = firstTypeRelation.DamageTypeName,
                        DamageFactor = damageFactor
                    };
                })
                .ToList();

            if (excludeNeutral)
            {
                weaknesses = weaknesses
                    .Where(x => x.DamageFactor != 100)
                    .ToList();
            }

            return weaknesses;
        }

        public static string GetPokedexNumberNationalFormated(this Pokemon p, bool withSuffix = true)
        {
            var suffix = String.Empty;

            if (withSuffix)
            {
                if (p.IsMega)
                {
                    suffix = "M";
                    if (p.IsMegaX)
                        suffix += "X";
                    else if (p.IsMegaY)
                        suffix += "Y";
                }
                else
                {
                    switch (p.SpecieId)
                    {
                        case 351: // Castform (Morphéo)
                        case 382: // Kyogre
                        case 383: // Groudon
                        case 386: // Deoxys
                        case 421: // Cherrim (Ceriflor)
                        case 422: // Shellos (Sankoki)
                        case 423: // Gastrodon (Tritosor)
                        case 487: // Giratina
                        case 492: // Shaymin
                        case 550: // Basculin (Bargantua)
                        case 555: // Darmanitan (Darumacho)
                        case 641: // Tornadus
                        case 642: // Thundurus
                        case 645: // Landorus (Demeteros)
                        case 646: // Kyurem
                        case 647: // Keldeo
                        case 648: // Meloetta
                        case 649: // Genesect
                        case 669: // Flabebe
                        case 670: // Floette
                        case 671: // Florges
                        case 678: // Meowstic (Mistigrix)
                        case 681: // Aegislash (Exagide)
                        case 716: // Xerneas
                        case 720: // Hoopa
                            suffix = p.FormIdentifier.Take();
                            break;
                        case 412: // Burmy (Cheniti)
                        case 413: // Wormadam (Cheniselle)
                        case 479: // Rotom (Motisma)
                        case 585: // Deerling (Vivaldaim)
                        case 586: // Sawsbuck (Haydaim)
                        case 676: // Furfrou (Couafarel)
                        case 710: // Pumpkaboo (Pitrouille)
                        case 711: // Gourgeist (Banshitrouye)
                            suffix = p.FormIdentifier.Take(2);
                            break;
                        case 666: // Vivillon (Prismillon)
                            suffix = p.FormIdentifier.Take(3);
                            break;
                        case 201: // Unown (Zarbi)
                            switch (p.FormIdentifier)
                            {
                                case "exclamation":
                                    suffix = "!";
                                    break;
                                case "question":
                                    suffix = "?";
                                    break;
                                default:
                                    suffix = p.FormIdentifier.Take();
                                    break;
                            }
                            break;
                    }
                }
            }

            return $"#{p.SpecieId:000}{suffix}";
        }

        public static string GetPokedexNumberNationalFormated(this PokemonUiModel p, bool withSuffix = true)
        {
            var suffix = string.Empty;

            if (withSuffix)
            {
                if (p.IsMega)
                {
                    suffix = "M";
                    if (p.IsMegaX)
                        suffix += "X";
                    else if (p.IsMegaY)
                        suffix += "Y";
                }
                else
                {
                    switch (p.SpecieId)
                    {
                        case 351: // Castform (Morphéo)
                        case 382: // Kyogre
                        case 383: // Groudon
                        case 386: // Deoxys
                        case 421: // Cherrim (Ceriflor)
                        case 422: // Shellos (Sankoki)
                        case 423: // Gastrodon (Tritosor)
                        case 487: // Giratina
                        case 492: // Shaymin
                        case 550: // Basculin (Bargantua)
                        case 555: // Darmanitan (Darumacho)
                        case 641: // Tornadus
                        case 642: // Thundurus
                        case 645: // Landorus (Demeteros)
                        case 646: // Kyurem
                        case 647: // Keldeo
                        case 648: // Meloetta
                        case 649: // Genesect
                        case 669: // Flabebe
                        case 670: // Floette
                        case 671: // Florges
                        case 678: // Meowstic (Mistigrix)
                        case 681: // Aegislash (Exagide)
                        case 716: // Xerneas
                        case 720: // Hoopa
                            suffix = p.FormIdentifier.Take();
                            break;
                        case 412: // Burmy (Cheniti)
                        case 413: // Wormadam (Cheniselle)
                        case 479: // Rotom (Motisma)
                        case 585: // Deerling (Vivaldaim)
                        case 586: // Sawsbuck (Haydaim)
                        case 676: // Furfrou (Couafarel)
                        case 710: // Pumpkaboo (Pitrouille)
                        case 711: // Gourgeist (Banshitrouye)
                            suffix = p.FormIdentifier.Take(2);
                            break;
                        case 666: // Vivillon (Prismillon)
                            suffix = p.FormIdentifier.Take(3);
                            break;
                        case 201: // Unown (Zarbi)
                            switch (p.FormIdentifier)
                            {
                                case "exclamation":
                                    suffix = "!";
                                    break;
                                case "question":
                                    suffix = "?";
                                    break;
                                default:
                                    suffix = p.FormIdentifier.Take();
                                    break;
                            }
                            break;
                    }
                }
            }

            return $"#{p.SpecieId:000}{suffix}";
        }

        public static PokemonFamily GetStade(this List<PokemonEvolution> evolutions)
        {
            var babies = evolutions.Where(x => x.IsBaby && x.EvolvesFromSpeciesId == null).ToList();
            var stade1 = babies.Any()
                ? evolutions.Where(x => babies.Any(y => y.PokemonId == x.EvolvesFromSpeciesId)).ToList()
                : evolutions.Where(x => x.EvolvesFromSpeciesId == null).ToList();
            var stade2 = evolutions.Where(x => stade1.Any(y => y.PokemonId == x.EvolvesFromSpeciesId)).ToList();
            var stade3 = evolutions.Where(x => stade2.Any(y => y.PokemonId == x.EvolvesFromSpeciesId)).ToList();
            var megas = evolutions.Where(x => x.IsMega).ToList();

            var pokemonFamily = new PokemonFamily();
            if (babies.Any())
                pokemonFamily.EvolutionStades.Add(new PokemonFamilyStade {Name = "Pré-évolution", Evolutions = babies});
            if (stade1.Any())
                pokemonFamily.EvolutionStades.Add(new PokemonFamilyStade {Name = "Stade 1", Evolutions = stade1});
            if (stade2.Any())
                pokemonFamily.EvolutionStades.Add(new PokemonFamilyStade {Name = "Stade 2", Evolutions = stade2});
            if (stade3.Any())
                pokemonFamily.EvolutionStades.Add(new PokemonFamilyStade {Name = "Stade 3", Evolutions = stade3});
            if (megas.Any())
                pokemonFamily.EvolutionStades.Add(new PokemonFamilyStade {Name = "Méga", Evolutions = megas});

            return pokemonFamily;
        }

        public static int CalculateHp(int b, int iv = 31, int ev = 255, int level = 100)
        {
            var partA = iv + (2 * b) + ((double)ev / 4) + 100;
            var partB = (partA * level / 100d) + 10;
            var result = Convert.ToInt32(Math.Floor(partB));
            return result;
        }

        public static int CalculateStat(int b, int iv = 31, int ev = 255, int level = 100, double nmod = 1.0)
        {
            var partA = iv + (2 * b) + ((double)ev / 4);
            var partB = ((partA * level / 100d) + 5) * nmod;
            var result = Convert.ToInt32(Math.Floor(partB));
            return result;
        }

        public static string CalculatePercentileHp(this Pokemon pokemon, List<Pokemon> comparisonList)
        {
            double countTotal = comparisonList.Count;
            double count = comparisonList.Count(x => x.BaseStatHp <= pokemon.BaseStatHp);
            double percentile = count * 100 / countTotal;
            return $"{percentile:F2}";
        }

        public static string CalculatePercentileAtk(this Pokemon pokemon, List<Pokemon> comparisonList)
        {
            double countTotal = comparisonList.Count;
            double count = comparisonList.Count(x => x.BaseStatAtk <= pokemon.BaseStatAtk);
            double percentile = count * 100 / countTotal;
            return $"{percentile:F2}";
        }

        public static string CalculatePercentileHp(this PokemonUiModel pokemon, List<PokemonUiModel> comparisonList)
        {
            double countTotal = comparisonList.Count;
            double count = comparisonList.Count(x => x.BaseStatHp <= pokemon.BaseStatHp);
            double percentile = count * 100 / countTotal;
            return $"{percentile:F2}";
        }

        public static string CalculatePercentileAtk(this PokemonUiModel pokemon, List<PokemonUiModel> comparisonList)
        {
            double countTotal = comparisonList.Count;
            double count = comparisonList.Count(x => x.BaseStatAtk <= pokemon.BaseStatAtk);
            double percentile = count * 100 / countTotal;
            return $"{percentile:F2}";
        }

        public static string FormatHeight(double height)
        {
            var part1 = $"{height / 10 * 3.28084:F1}".Replace(',', '\'') + "\"";
            var part2 = $"{height / 10:F2}".Replace(',', '.');
            return $"{part1} ({part2} m)";
        }

        public static string FormatWeight(double weight)
        {
            var part1 = $"{weight / 10 * 2.20462:F2}".Replace(',', '.');
            var part2 = $"{weight / 10:F1}".Replace(',', '.');
            return $"{part1} lbs ({part2} kg)";
        }
    }
}