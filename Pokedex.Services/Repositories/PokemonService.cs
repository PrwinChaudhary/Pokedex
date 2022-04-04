using Pokedex.DataAccess.Repositories.Interfaces;
using Pokedex.Extensions;
using Pokedex.Services.Repositories.Interfaces;
using Pokedex.Services.Response;
using System;

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

        /// <summary>
        /// Service method to call repository to get Pokemon basic information and Map to Response class
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PokedexResponseDto GetAllPokemonInformation(string name)
        {
            return _pokeApiClientRepository.GetPokemonBasicData(name).Result?.MapToResponseDto();
        }

        /// <summary>
        /// Ge Translation Strategy - Check and call translation strategy(Yoda or Shakespeare)
        /// </summary>
        /// <param name="pokemonInformation"></param>
        /// <returns></returns>
        private PokedexResponseDto GeTranslationStrategy(PokedexResponseDto pokemonInformation)
        {
            // Check Condition if Yoda Translation required for description or not - Its required if Pokemon's Habitat is "cave" or if it's a legendary Pokemon
            bool isYodaTranslationRequired = string.Equals(pokemonInformation.Habitat, CaveHabitat, StringComparison.OrdinalIgnoreCase) || pokemonInformation.IsLegendary;

            // Call Fun translation Repository with required Translation decision
            pokemonInformation.Description = _translationClientRepository.GetTranslatedDescription(pokemonInformation.Description, isYodaTranslationRequired).Result;
            return pokemonInformation;
        }

        /// <summary>
        /// Service method to call repository to get Pokemon information with Fun translation and Map to Response class
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PokedexResponseDto GetPokemonDataWithTranslation(string name)
        {
            var pokemonData = GetAllPokemonInformation(name);
            if (pokemonData != null && !string.IsNullOrEmpty(pokemonData.Description))
            {
                pokemonData = GeTranslationStrategy(pokemonData);
            }

            return pokemonData;
        }
    }
}
