using Pokedex.DataAccess.Models;
using Pokedex.DataAccess.Repositories.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Pokedex.Client.Utils;

namespace Pokedex.DataAccess.Repositories
{
    public class TranslationClientRepository : BaseClientRepository, ITranslationClientRepository
    {
        public async Task<string> GetTranslatedDescription(string description, bool isYodaTranslationRequired)
        {
            var url = isYodaTranslationRequired ? ApplicationConfig.YodaApiUrl : ApplicationConfig.ShakespeareApiUrl;
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(new { text = description }),
                RequestUri = new Uri(url)
            };

            TranslationResponse translatedResp = await SendRequest<TranslationResponse>(request);
            if (translatedResp?.Success.Total > 0)
            {
                return translatedResp.Contents.Translated;
            }
            return string.Empty;
        }
    }
}
