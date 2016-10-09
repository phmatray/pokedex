using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PokedexG.Uwp.Models.Filtering
{
    public abstract class Store<TModel> : ObservableCollection<TModel>
    {
        protected Store(IEnumerable<TModel> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        public abstract Task Create(TModel item);
        public abstract Task Update(TModel item);
        public abstract Task Delete(TModel item);
    }
}