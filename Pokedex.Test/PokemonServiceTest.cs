using Moq;
using NUnit.Framework;
using Pokedex.DataAccess.Models;
using Pokedex.DataAccess.Repositories.Interfaces;
using Pokedex.Services.Repositories;
using Pokedex.Services.Repositories.Interfaces;

namespace Pokedex.Test
{
    public class PokemonServiceTest
    {
        private IPokeApiClientRepository pokeApiClientRepository;
        private ITranslationClientRepository translationClientRepository;
        private IPokeApiClientRepository getPokemonDataInformation()
        {
            Mock<IPokeApiClientRepository> mockObject = new Mock<IPokeApiClientRepository>();
            mockObject.Setup(m => m.GetPokemonBasicData("mewtwo").Result).Returns(new PokemonInformation() { Name = "mewtwo", Descriptions = new System.Collections.Generic.List<PokemonDescription>() { new PokemonDescription() { Description = "mewtwo", Language = new Language() { Name = "en" } } }, Habitat = new PokemonHabitat { Name = "Cave" } });
            return mockObject.Object;
        }

        private IPokeApiClientRepository getPokemonDataShakespeareInformation()
        {
            Mock<IPokeApiClientRepository> mockObject = new Mock<IPokeApiClientRepository>();
            mockObject.Setup(m => m.GetPokemonBasicData("mewtwo").Result).Returns(new PokemonInformation() { Name = "mewtwo", Descriptions = new System.Collections.Generic.List<PokemonDescription>() { new PokemonDescription() { Description = "mewtwo", Language = new Language() { Name = "en" } } } });
            return mockObject.Object;
        }

        private ITranslationClientRepository getYodaTraslatedDescription()
        {
            Mock<ITranslationClientRepository> mockObject = new Mock<ITranslationClientRepository>();
            mockObject.Setup(m => m.GetTranslatedDescription("mewtwo", true).Result).Returns("mewtw");
            return mockObject.Object;
        }

        private ITranslationClientRepository getShakespeareTraslatedDescription()
        {
            Mock<ITranslationClientRepository> mockObject = new Mock<ITranslationClientRepository>();
            mockObject.Setup(m => m.GetTranslatedDescription("mewtwo", false).Result).Returns("mew");
            return mockObject.Object;
        }

        [SetUp]
        public void Setup()
        {
            pokeApiClientRepository = getPokemonDataInformation();
            translationClientRepository = getYodaTraslatedDescription();

        }

        [Test]
        public void ForPokemonName_Should_Return_Valid_Name()
        {
            IPokemonService pokemon = new PokemonService(pokeApiClientRepository, translationClientRepository);
            var result = pokemon.GetAllPokemonInformation("mewtwo");

            Assert.AreEqual("mewtwo", result.Name);
        }

        [Test]
        public void IfNameIsNotFound_Should_Return_ValidResult()
        {
            IPokemonService pokemon = new PokemonService(pokeApiClientRepository, translationClientRepository);
            var result = pokemon.GetAllPokemonInformation("");
            Assert.IsNull(result);
        }

        [Test]
        public void ForPokemonName_Should_Return_Valid_YodaTranslatedDescription()
        {
            IPokemonService pokemon = new PokemonService(pokeApiClientRepository, translationClientRepository);
            var result = pokemon.GetPokemonDataWithTranslation("mewtwo");

            Assert.AreEqual("mewtw", result.Description);
        }

        [Test]
        public void ForYodaTranslationIfNameIsNotFound_Should_Return_Null()
        {
            IPokemonService pokemon = new PokemonService(pokeApiClientRepository, translationClientRepository);
            var result = pokemon.GetPokemonDataWithTranslation("");
            Assert.IsNull(result);
        }

        [Test]
        public void ForPokemonName_Should_Return_Valid_ShakespeareTranslatedDescription()
        {
            translationClientRepository = getShakespeareTraslatedDescription();
            pokeApiClientRepository = getPokemonDataShakespeareInformation();
            IPokemonService pokemon = new PokemonService(pokeApiClientRepository, translationClientRepository);
            var result = pokemon.GetPokemonDataWithTranslation("mewtwo");

            Assert.AreEqual("mew", result.Description);
        }

        [Test]
        public void ForShakespeareTranslationIfNameIsNotFound_Should_Return_Null()
        {
            translationClientRepository = getShakespeareTraslatedDescription();
            pokeApiClientRepository = getPokemonDataShakespeareInformation();
            IPokemonService pokemon = new PokemonService(pokeApiClientRepository, translationClientRepository);
            var result = pokemon.GetPokemonDataWithTranslation("");
            Assert.IsNull(result);
        }
    }
}
