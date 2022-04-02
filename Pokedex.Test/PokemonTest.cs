using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Pokedex.Controllers;
using Pokedex.DataAccess.Models;
using Pokedex.DataAccess.Repositories.Interfaces;
using Pokedex.Dto.Response;

namespace Pokedex.Test
{
    
    public class PokemonTest
    {
        private  PokemonController _controller;
        private IPokemonSpecies getPokemonSpecies()
        {
            Mock<IPokemonSpecies> mockObject = new Mock<IPokemonSpecies>();
            mockObject.Setup(m => m.GetAllPokemonInformation("mewtwo")).Returns(new PokemonInformation{Name = "mewtwo"});
            return mockObject.Object;
        }

        [SetUp]
        public void Setup()
        {
            IPokemonSpecies pokemonSpecies = getPokemonSpecies();
            _controller = new PokemonController(pokemonSpecies);
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