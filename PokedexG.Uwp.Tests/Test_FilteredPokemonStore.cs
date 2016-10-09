//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
//using PokedexG.Uwp.Models.Filtering;

//namespace PokedexG.UnitTestProject
//{
//    [TestClass]
//    public class Test_FilteredPokemonStore
//    {
//        [TestCategory("Stores")]
//        [TestMethod]
//        public async Task Test_FilteredPokemonStore_Request()
//        {
//            var store = new FilteredPokemonStore(await PokemonStore.Load());
            
//            Assert.IsTrue(store.Count > 0);
//        }
//    }
//}