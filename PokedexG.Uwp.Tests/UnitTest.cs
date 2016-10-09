using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PokemonAPI;

namespace PokedexG.Uwp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Test_GetType_ById()
        {
            var dataFetcher = new DataFetcher();
            var typeResource = await dataFetcher.GetType(3);
            Assert.AreEqual(3, typeResource.Id);
        }
    }
}
