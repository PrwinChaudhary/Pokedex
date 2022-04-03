using System;
using Pokedex.Client.Utils;
using Pokedex.DataAccess.Repositories.Interfaces;
using Pokedex.Dto.Response;
using Pokedex.Extensions;
using Pokedex.Services.Repositories.Interfaces;

namespace Pokedex.Services.Repositories
{
    public class PokemonService : IPokemonService
    {
        private const string CaveHabitat = "cave";
        private readonly IPokeApiClientRepository _pokeApiClientRepository;
        private readonly ITranslationClientRepository _translationClientRepository;

        public PokemonService(IPokeApiClientRepository pokeApiClientRepository, ITranslationClientRepository translationClientRepository)
        {
            _pokeApiClientRepository = pokeApiClientRepository;
            _translationClientRepository = translationClientRepository;
        }

        public PokedexResponseDto GetAllPokemonInformation(string name)
        {
            return _pokeApiClientRepository.GetPokemonBasicData(name).Result?.MapToResponseDto();
        }

        private PokedexResponseDto GeTranslationStrategy(PokedexResponseDto pokemonInformation)
        {
            bool isYodaTranslationRequired = string.Equals(pokemonInformation.Habitat, CaveHabitat, StringComparison.OrdinalIgnoreCase) || pokemonInformation.IsLegendary;
            pokemonInformation.Description = _translationClientRepository.GetTranslatedDescription(pokemonInformation.Description, isYodaTranslationRequired).Result;
            return pokemonInformation;
        }

        public PokedexResponseDto GetPokemonDataWithTranslation(string name)
        {
            var pokemonData = GetAllPokemonInformation(name);
            if (pokemonData != null)
            {
                pokemonData = GeTranslationStrategy(pokemonData);
            }

            return pokemonData;
        }
    }
}
