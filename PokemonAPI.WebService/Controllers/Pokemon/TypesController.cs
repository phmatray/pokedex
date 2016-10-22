using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Type = PokemonAPI.Models.Rsc.Type;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/types")]
    public class TypesController : ApiController
    {
        private readonly VeekunContext _context;

        public TypesController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/types
        // GET api/v1/types?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset, _context.Types, this.Segment());
        }

        // GET api/v1/types/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var type = await _context.Types
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Type
                {
                    Id              = type.Id,
                    Name            = type.Identifier,
                    DamageRelations = await GetDamageRelations(type),
                    GameIndices     = await GetGameIndices(type),
                    Generation      = await GetGeneration(type),
                    MoveDamageClass = await GetMoveDamageClass(type),
                    Names           = await GetNames(type),
                    Pokemon         = await GetPokemon(type),
                    Moves           = await GetMoves(type)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private async Task<TypeRelations> GetDamageRelations(EFTypes type)
        {
            return new TypeRelations
            {
                NoDamageTo       = await GetDamageTypesTo(x => x.DamageTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageTo     = await GetDamageTypesTo(x => x.DamageTypeId == type.Id && x.DamageFactor == 50),
                DoubleDamageTo   = await GetDamageTypesTo(x => x.DamageTypeId == type.Id && x.DamageFactor == 200),
                NoDamageFrom     = await GetDamageTypesFrom(x => x.TargetTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageFrom   = await GetDamageTypesFrom(x => x.TargetTypeId == type.Id && x.DamageFactor == 50),
                DoubleDamageFrom = await GetDamageTypesFrom(x => x.TargetTypeId == type.Id && x.DamageFactor == 200)
            };
        }

        private async Task<List<NamedAPIResource>> GetDamageTypesTo(Expression<Func<EFTypeEfficacy, bool>> expression)
        {
            return (await _context
                    .TypeEfficacy
                    .Include(x => x.TargetType)
                    .Where(expression)
                    .ToListAsync())
                .Select(x => x.TargetType.ToNamedApiResource(this.Segment()))
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetDamageTypesFrom(Expression<Func<EFTypeEfficacy, bool>> expression)
        {
            return (await _context
                    .TypeEfficacy
                    .Include(x => x.DamageType)
                    .Where(expression)
                    .ToListAsync())
                .Select(x => x.DamageType.ToNamedApiResource(this.Segment()))
                .ToList();
        }

        private async Task<List<GenerationGameIndex>> GetGameIndices(EFTypes type)
        {
            return (await _context
                    .TypeGameIndices
                    .Include(x => x.Generation)
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => new GenerationGameIndex
                {
                    GameIndex = x.GameIndex,
                    Generation = x.Generation.ToNamedApiResource(typeof(GenerationsController).Segment())
                })
                .ToList();
        }

        private async Task<NamedAPIResource> GetGeneration(EFTypes type)
        {
            return (await _context
                    .Generations
                    .Include(x => x.Types)
                    .Where(x => x.Types.Any(y => y.Id == type.Id))
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource(typeof(GenerationsController).Segment());
        }

        private async Task<NamedAPIResource> GetMoveDamageClass(EFTypes type)
        {
            return (await _context
                    .MoveDamageClasses
                    .Include(x => x.Types)
                    .Where(x => x.Types.Any(y => y.Id == type.Id))
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource(typeof(MoveDamageClassesController).Segment());
        }

        private async Task<List<Name>> GetNames(EFTypes type)
        {
            return (await _context
                    .TypeNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => new Name(x.Name, 
                    x.LocalLanguage.ToNamedApiResource(typeof(LanguagesController).Segment())))
                .ToList();
        }

        private async Task<List<TypePokemon>> GetPokemon(EFTypes type)
        {
            return (await _context
                    .PokemonTypes
                    .Include(x => x.Pokemon)
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => new TypePokemon
                {
                    Slot = x.Slot,
                    Pokemon = x.Pokemon.ToNamedApiResource(typeof(PokemonsController).Segment())
                })
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetMoves(EFTypes type)
        {
            return (await _context
                    .Moves
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource(typeof(MovesController).Segment()))
                .ToList();
        }
    }
}