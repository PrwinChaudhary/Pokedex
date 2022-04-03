using Moq;
using NUnit.Framework;
using Pokedex.Controllers;
using Pokedex.Services.Repositories.Interfaces;
using Pokedex.Services.Response;

namespace Pokedex.Test
{

    public class PokemonTest
    {
        private  PokemonController _controller;
        private IPokemonService getPokemonDataInformation()
        {
            Mock<IPokemonService> mockObject = new Mock<IPokemonService>();
            mockObject.Setup(m => m.GetAllPokemonInformation("mewtwo")).Returns(new PokedexResponseDto(){Name = "mewtwo"});
            return mockObject.Object;
        }

        [SetUp]
        public void Setup()
        {
            IPokemonService pokemonService = getPokemonDataInformation();
            _controller = new PokemonController(pokemonService);
        }

        [Test]
        public void ForPokemonName_Should_Return_Valid_Name()
        {
            if (_controller.Get("mewtwo").Value is PokedexResponseDto result) 
                Assert.AreEqual("mewtwo", result.Name);
        }

        [Test]
        public void IfNameIsNotFound_Should_Return_EmptyResult()
        {
           object result = _controller.Get("test").Value ;
            Assert.AreEqual("No Data Found for test", result);
        }

        [Test]
        public void IfNameIsEmpty_Should_Return_EmptyResult()
        {
            object result = _controller.Get("").Value;
            Assert.AreEqual("No Data Found for ", result);
        }
    }
}