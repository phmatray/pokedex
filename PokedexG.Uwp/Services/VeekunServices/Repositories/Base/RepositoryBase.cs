using System.Collections.Generic;
using System.Linq;
using PokedexG.Uwp.Utils.SQLiteHelpers;

namespace PokedexG.Uwp.Services.VeekunServices.Repositories
{
    public abstract class RepositoryBase<TModel>
        where TModel : class
    {
        private static List<TModel> _all;
        public static List<TModel> All => _all ?? (_all = GetAll());

        private static List<TModel> GetAll()
        {
            var db = PokemonDbConnection.DbConnection;
            
            // Activate Tracing 
            db.TraceListener = new DebugTraceListener();

            // Get Result
            return db.Table<TModel>()
                .ToList();
        }
    }
}