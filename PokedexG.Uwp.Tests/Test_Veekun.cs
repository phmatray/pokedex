//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
//using PokedexG.Uwp.Services.VeekunServices;

//namespace PokedexG.UnitTestProject
//{
//    [TestClass]
//    public class Test_Veekun
//    {
//        [TestCategory("Services")]
//        [TestMethod]
//        public async Task Test_Veekun_GetPokemons_Request()
//        {
//            var results = await Veekun.GetPokemons();
            
//            Assert.IsTrue(results.Any());
//        }

//        [TestCategory("Services")]
//        [TestMethod]
//        public async Task Test_Veekun_GetMachines_Request()
//        {
//            var results = await Veekun.GetMachines();
            
//            Assert.IsTrue(results.Any());
//        }

//        [TestCategory("Services")]
//        [TestMethod]
//        public async Task Test_Veekun_GetPokedexes_Request()
//        {
//            var results = await Veekun.GetPokedexes();
            
//            Assert.IsTrue(results.Any());
//        }
//    }
//}
