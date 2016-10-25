using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using Type = PokemonAPI.Models.Rsc.Type;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PokemonAPI.WebService.Controllers._Base;

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
            => await GetAll(limit, offset, _context.Types, GetType());

        // GET api/v1/types/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var type = await _context.Types
                    .Include(x => x.TypeEfficacyDamageType).ThenInclude(x => x.TargetType)
                    .Include(x => x.TypeEfficacyTargetType).ThenInclude(x => x.DamageType)
                    .Include(x => x.TypeGameIndices).ThenInclude(x => x.Generation)
                    .Include(x => x.Generation)
                    .Include(x => x.DamageClass)
                    .Include(x => x.TypeNames).ThenInclude(x => x.LocalLanguage)
                    .Include(x => x.PokemonTypes).ThenInclude(x => x.Pokemon)
                    .Include(x => x.Moves)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var result = new Type
                {
                    Id              = type.Id,
                    Name            = type.Identifier,
                    DamageRelations = GetDamageRelations(type),
                    GameIndices     = GetGameIndices(type),
                    Generation      = GetGeneration(type),
                    MoveDamageClass = GetMoveDamageClass(type),
                    Names           = GetNames(type),
                    Pokemon         = GetPokemon(type),
                    Moves           = GetMoves(type)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private static TypeRelations GetDamageRelations(EFTypes type)
        {
            return new TypeRelations
            {
                NoDamageTo       = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageTo     = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 50),
                NormalDamageTo   = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 100),
                DoubleDamageTo   = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 200),
                NoDamageFrom     = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageFrom   = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 50),
                NormalDamageFrom = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 100),
                DoubleDamageFrom = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 200)
            };
        }

        private static List<NamedAPIResource> DamageTo(EFTypes type, Func<EFTypeEfficacy, bool> predicate)
        {
            return type
                .TypeEfficacyDamageType
                .Where(predicate)
                .Select(x => x.TargetType.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> DamageFrom(EFTypes type, Func<EFTypeEfficacy, bool> predicate)
        {
            return type
                .TypeEfficacyTargetType
                .Where(predicate)
                .Select(x => x.DamageType.ToNamedApiResource())
                .ToList();
        }

        private static List<GenerationGameIndex> GetGameIndices(EFTypes type)
        {
            return type
                .TypeGameIndices
                .Select(x => new GenerationGameIndex(x.GameIndex, x.Generation.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetGeneration(EFTypes type)
        {
            return type
                .Generation
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetMoveDamageClass(EFTypes type)
        {
            return type
                .DamageClass
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFTypes type)
        {
            return type
                .TypeNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<TypePokemon> GetPokemon(EFTypes type)
        {
            return type
                .PokemonTypes
                .Select(x => new TypePokemon(x.Slot, x.Pokemon.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetMoves(EFTypes type)
        {
            return type
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}