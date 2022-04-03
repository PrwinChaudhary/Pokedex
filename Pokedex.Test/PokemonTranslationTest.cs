using Moq;
using NUnit.Framework;
using Pokedex.Controllers;
using Pokedex.Dto.Response;
using Pokedex.Services.Repositories.Interfaces;

namespace Pokedex.Test
{
    public class PokemonTranslationTest
    {
        private PokemonController _controller;
        private IPokemonService getPokemonTranslatedDataInformation()
        {
            Mock<IPokemonService> mockObject = new Mock<IPokemonService>();
            mockObject.Setup(m => m.GetPokemonDataWithTranslation("mewtwo")).Returns(new PokedexResponseDto() { Name = "mewtwo",Description = "Mock Description"});
            return mockObject.Object;
        }

        [SetUp]
        public void Setup()
        {
            IPokemonService pokemonService = getPokemonTranslatedDataInformation();
            _controller = new PokemonController(pokemonService);
        }

        [Test]
        public void ForValidPokemonName_Should_Return_Valid_TranslatedDescription()
        {
            if (_controller.Get("mewtwo").Value is PokedexResponseDto result)
                Assert.AreEqual("Mock Description", result.Description);
        }

        [Test]
        public void IfDescriptionNotFound_Should_Return_EmptyResult()
        {
            object result = _controller.Get("test").Value;
            Assert.AreEqual("No Data Found for test", result);
        }

        [Test]
        public void IfDataNotFound_Should_Return_EmptyResult()
        {
            object result = _controller.Get("").Value;
            Assert.AreEqual("No Data Found for ", result);
        }
    }
}
