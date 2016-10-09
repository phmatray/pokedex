using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using PokedexG.Uwp.Utils;

namespace PokedexG.Uwp.Models.Filtering
{
    /// <summary>
    /// A filtered version of the task store.
    /// </summary>
    public class FilteredPokemonStore : INotifyCollectionChanged, IList
    {
        private readonly Random _random;
        private readonly PokemonStore _store;
        private readonly List<Pokemon> _view;

        /// <summary>
        /// Create a new FilteredTaskStore based on an existing TaskStore
        /// </summary>
        /// <param name="store">The TaskStore to base this filter on</param>
        public FilteredPokemonStore(PokemonStore store)
        {
            _random = new Random();
            _store = store;
            _view = new List<Pokemon>(_store);
        }

        public bool IncludeMegaEvolutions { get; set; } = true;
        public bool IncludeAlternatives { get; set; } = true;
        public PokemonSorting SortMethod { get; set; } = PokemonSorting.None;
        public string Filter { get; set; } = string.Empty;


        #region IList Interface

        public object this[int index]
        {
            get { return _view[index]; }
            set { throw new InvalidOperationException(); }
        }

        public int Count => _view.Count;
        public bool IsFixedSize => ((IList) _view).IsFixedSize;
        public bool IsReadOnly => ((IList) _view).IsReadOnly;
        public bool IsSynchronized => ((IList) _view).IsSynchronized;
        public object SyncRoot => ((IList) _view).SyncRoot;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public int Add(object value) => ((IList) _view).Add(value);
        public void Clear() => ((IList) _view).Clear();
        public bool Contains(object value) => ((IList) _view).Contains(value);
        public void CopyTo(Array array, int index) => ((IList) _view).CopyTo(array, index);
        public IEnumerator GetEnumerator() => ((IList) _view).GetEnumerator();
        public int IndexOf(object value) => ((IList) _view).IndexOf(value);
        public void Insert(int index, object value) => ((IList) _view).Insert(index, value);
        public void Remove(object value) => ((IList) _view).Remove(value);
        public void RemoveAt(int index) => ((IList) _view).RemoveAt(index);

        #endregion

        #region TaskStore interface

        /// <summary>
        /// Create a new Task asynchronously
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Create(Pokemon item)
        {
            await _store.Create(item);
            RefreshView();
        }

        /// <summary>
        /// Update a task asynchronously
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Update(Pokemon item)
        {
            await _store.Update(item);
            RefreshView();
        }

        /// <summary>
        /// Delete a task asynchronously
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Delete(Pokemon item)
        {
            await _store.Delete(item);
            RefreshView();
        }

        #endregion

        public Pokemon PickRandom()
        {
            var index = _random.Next(_view.Count);
            var pokemon = _view[index];
            return pokemon;
        }

        /// <summary>
        /// Refresh the view, based on filters and sorting mechanisms.
        /// </summary>
        public void RefreshView()
        {
            IEnumerable<Pokemon> pokemons = _store.ToList();
            if (!IncludeMegaEvolutions)
                pokemons = pokemons.Where(x => !x.IsMega && !x.IsPrimal);
            if (!IncludeAlternatives)
                pokemons = pokemons.Where(x => !x.IsAlternative);

            if (Filter != string.Empty)
            {
                pokemons = pokemons
                    .Where(x =>
                    {
                        var filter = Filter.RemoveDiacritics().ToUpper();
                        var name = x.Name.RemoveDiacritics().ToUpper();
                        var type1 = x.Type1Name.ToUpper();
                        var type2 = x.Type2Name?.RemoveDiacritics().ToUpper() ?? string.Empty;
                        var number = x.PokedexNumberNationalFormatedWithSuffix?.ToString() ?? string.Empty;

                        return name.Contains(filter) ||
                               type1.StartsWith(filter) ||
                               type2.StartsWith(filter) ||
                               number.Contains(filter);
                    });
            }

            switch (SortMethod)
            {
                case PokemonSorting.None:
                    break;
                case PokemonSorting.ByNumber:
                    pokemons = pokemons.OrderBy(x => x.PokedexNumberNationalFormatedWithSuffix);
                    break;
                case PokemonSorting.ByName:
                    pokemons = pokemons.OrderBy(x => x.Name);
                    break;
                case PokemonSorting.ByEvolution:
                    pokemons = pokemons.OrderBy(x => x.Order);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _view.Clear();
            _view.AddRange(pokemons);
            // Call the event handler for the updated list.
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}