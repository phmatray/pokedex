// RECONSTRUCTION 2026-07-23 — Load() (qui appelait Veekun, couche données) devient un
// constructeur public : la liste est fournie par l'appelant. Le reste est verbatim.
using System.Collections.Generic;
using System.Threading.Tasks;

#pragma warning disable 1998

namespace PokedexG.Uwp.Models.Filtering
{
    /// <summary>
    /// Implementation of the PokemonStore - this is a basic
    /// CRUD type store.
    /// </summary>
    public class PokemonStore : Store<Pokemon>
    {
        public PokemonStore(IEnumerable<Pokemon> collection)
            : base(collection)
        {
        }

        public override async Task Create(Pokemon item)
        {
            Add(item);
        }

        public override async Task Update(Pokemon item)
        {
            for (var idx = 0; idx < Count; idx++)
            {
                if (Items[idx].PokemonId.Equals(item.PokemonId))
                    Items[idx] = item;
            }
        }

        public override async Task Delete(Pokemon item)
        {
            Remove(item);
        }
    }
}