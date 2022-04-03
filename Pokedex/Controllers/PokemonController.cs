using Microsoft.AspNetCore.Mvc;
using Pokedex.Services.Repositories.Interfaces;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonSpecies)
        {
            _pokemonService = pokemonSpecies;

        }

        [HttpGet("{name}")]

        public ObjectResult Get(string name)
        {
            var pokemonResult = _pokemonService.GetAllPokemonInformation(name);
            if (pokemonResult == null)
            {
                return new NotFoundObjectResult($"No Data Found for {name}");
            }

            return new ObjectResult(pokemonResult);
        }

        [HttpGet("translated/{name}")]

        public ObjectResult GetTranslatedPokemon(string name)
        {
            var pokemonResult = _pokemonService.GetPokemonDataWithTranslation(name);
            if (pokemonResult == null)
            {
                return new NotFoundObjectResult($"No Data Found for {name}");
            }

            return new ObjectResult(pokemonResult);
        }
    }
}
