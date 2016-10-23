using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/evolution-chains")]
    public class EvolutionChainsController : ApiController
    {
        private readonly VeekunContext _context;

        public EvolutionChainsController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/evolution-chains
        // GET api/v1/evolution-chains?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            try
            {
                if (limit <= 0) throw new ArgumentOutOfRangeException(nameof(limit));
                if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

                var dbset = _context.EvolutionChains;
                var urlSegment = typeof(EvolutionChainsController).Segment();

                var count = await dbset.CountAsync();
                var previous = Previous(limit, offset, urlSegment);
                var next = Next(limit, offset, count, urlSegment);

                var apiResults = (await dbset
                        .OrderBy(x => x.Id)
                        .Skip(offset)
                        .Take(limit)
                        .ToListAsync())
                    .Select(x => x.ToApiResource(urlSegment))
                    .ToList();

                var results = new APIResourceList(count, previous, next, apiResults);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/v1/evolution-chains/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var evolutionChain = await _context.EvolutionChains
                    .Include(x => x.BabyTriggerItem)
                    .Include(x => x.PokemonSpecies)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var firstStadeSpecies = evolutionChain
                    .PokemonSpecies
                    .Single(x => x.EvolvesFromSpeciesId == null);

                var result = new EvolutionChain
                {
                    Id              = evolutionChain.Id,
                    BabyTriggerItem = GetBabyTriggerItem(evolutionChain),
                    Chain           = GetChain(firstStadeSpecies)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private NamedAPIResource GetBabyTriggerItem(EFEvolutionChains evolutionChain)
        {
            return evolutionChain
                .BabyTriggerItem?
                .ToNamedApiResource<ItemsController>();
        }

        private ChainLink GetChain(EFPokemonSpecies firstStadeSpecies)
        {
            return new ChainLink
            {
                IsBaby = firstStadeSpecies.IsBaby,
                Species = firstStadeSpecies.ToNamedApiResource<PokemonSpeciesController>(),
                EvolutionDetails = new List<EvolutionDetail>(),
                EvolvesTo = GetEvolvesToChainLinks(firstStadeSpecies)
            };
        }

        private List<ChainLink> GetEvolvesToChainLinks(EFPokemonSpecies species)
        {
            var evolutionsFromSpecies = _context
                .PokemonSpecies
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.TriggerItem)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.EvolutionTrigger)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.HeldItem)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.KnownMove)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.KnownMoveType)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.Location)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.PartySpecies)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.PartyType)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.TradeSpecies)
                .Single(x => x.Id == species.Id)
                .InverseEvolvesFromSpecies
                .ToList();

            return evolutionsFromSpecies
                .Select(evolution => new ChainLink
                {
                    IsBaby = evolution.IsBaby,
                    Species = evolution.ToNamedApiResource<PokemonSpeciesController>(),
                    EvolutionDetails = evolution
                        .PokemonEvolutionEvolvedSpecies
                        .Select(x => new EvolutionDetail
                        {
                            Item                  = x.TriggerItem?.ToNamedApiResource<ItemsController>(),
                            Trigger               = x.EvolutionTrigger?.ToNamedApiResource<EvolutionTriggersController>(),
                            Gender                = x.GenderId,
                            HeldItem              = x.HeldItem?.ToNamedApiResource<ItemsController>(),
                            KnownMove             = x.KnownMove?.ToNamedApiResource<MovesController>(),
                            KnownMoveType         = x.KnownMoveType?.ToNamedApiResource<TypesController>(),
                            Location              = x.Location?.ToNamedApiResource<LocationsController>(),
                            MinLevel              = x.MinimumLevel,
                            MinHappiness          = x.MinimumHappiness,
                            MinBeauty             = x.MinimumBeauty,
                            MinAffection          = x.MinimumAffection,
                            NeedsOverworldRain    = x.NeedsOverworldRain,
                            PartySpecies          = x.PartySpecies?.ToNamedApiResource<PokemonSpeciesController>(),
                            PartyType             = x.PartyType?.ToNamedApiResource<TypesController>(),
                            RelativePhysicalStats = x.RelativePhysicalStats,
                            TimeOfDay             = x.TimeOfDay,
                            TradeSpecies          = x.TradeSpecies?.ToNamedApiResource<PokemonSpeciesController>(),
                            TurnUpsideDown        = x.TurnUpsideDown
                        }).ToList(),
                    EvolvesTo = GetEvolvesToChainLinks(evolution)
                })
                .ToList();
        }
    }
}