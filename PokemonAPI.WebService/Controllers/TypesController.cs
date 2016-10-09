using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Resources;
using PokemonAPI.WebService.Controllers.Base;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/[controller]")]
    public class TypesController : ApiController<Types>
    {
        public TypesController(VeekunContext context)
            : base(context)
        {
        }

        // GET api/v1/types
        // GET api/v1/types?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            return await base.GetAll(limit, offset);
        }

        // GET api/v1/types/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var type = await MainDbSet
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new TypeResource
                {
                    Id              = type.Id,
                    Identifier      = type.Identifier,
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

        private async Task<TypeRelationsResource> GetDamageRelations(Types type)
        {
            return new TypeRelationsResource
            {
                NoDamageTo       = await GetDamageTypesTo(x => x.DamageTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageTo     = await GetDamageTypesTo(x => x.DamageTypeId == type.Id && x.DamageFactor == 50),
                NormalDamageTo   = await GetDamageTypesTo(x => x.DamageTypeId == type.Id && x.DamageFactor == 100),
                DoubleDamageTo   = await GetDamageTypesTo(x => x.DamageTypeId == type.Id && x.DamageFactor == 200),
                NoDamageFrom     = await GetDamageTypesFrom(x => x.TargetTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageFrom   = await GetDamageTypesFrom(x => x.TargetTypeId == type.Id && x.DamageFactor == 50),
                NormalDamageFrom = await GetDamageTypesFrom(x => x.TargetTypeId == type.Id && x.DamageFactor == 100),
                DoubleDamageFrom = await GetDamageTypesFrom(x => x.TargetTypeId == type.Id && x.DamageFactor == 200)
            };
        }

        private async Task<List<NamedAPIResource>> GetDamageTypesTo(Expression<Func<TypeEfficacy, bool>> expression)
        {
            return (await Context
                    .TypeEfficacy
                    .Include(x => x.TargetType)
                    .Where(expression)
                    .ToListAsync())
                .Select(x => x.TargetType.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetDamageTypesFrom(Expression<Func<TypeEfficacy, bool>> expression)
        {
            return (await Context
                    .TypeEfficacy
                    .Include(x => x.TargetType)
                    .Where(expression)
                    .ToListAsync())
                .Select(x => x.DamageType.ToNamedApiResource())
                .ToList();
        }

        private async Task<List<GenerationGameIndexResource>> GetGameIndices(Types type)
        {
            return (await Context
                    .TypeGameIndices
                    .Include(x => x.Generation)
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => new GenerationGameIndexResource
                {
                    GameIndex = x.GameIndex,
                    Generation = x.Generation.ToNamedApiResource()
                })
                .ToList();
        }

        private async Task<NamedAPIResource> GetGeneration(Types type)
        {
            return (await Context
                    .Generations
                    .Include(x => x.Types)
                    .Where(x => x.Types.Any(y => y.Id == type.Id))
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource();
        }

        private async Task<NamedAPIResource> GetMoveDamageClass(Types type)
        {
            return (await Context
                    .MoveDamageClasses
                    .Include(x => x.Types)
                    .Where(x => x.Types.Any(y => y.Id == type.Id))
                    .FirstOrDefaultAsync())?
                .ToNamedApiResource();
        }

        private async Task<List<NameResource>> GetNames(Types type)
        {
            return (await Context
                    .TypeNames
                    .Include(x => x.LocalLanguage)
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => x.ToNameResource())
                .ToList();
        }

        private async Task<List<TypePokemonResource>> GetPokemon(Types type)
        {
            return (await Context
                    .PokemonTypes
                    .Include(x => x.Pokemon)
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => new TypePokemonResource
                {
                    Slot = x.Slot,
                    Pokemon = x.Pokemon.ToNamedApiResource()
                })
                .ToList();
        }

        private async Task<List<NamedAPIResource>> GetMoves(Types type)
        {
            return (await Context
                    .Moves
                    .Where(x => x.TypeId == type.Id)
                    .ToListAsync())
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}