using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.DataAccess.Repositories
{
    public abstract class BaseClientRepository
    {

        protected static async Task<T> SendRequest<T>(HttpRequestMessage httpRequest) where T : new()
        {
            T result = new T();
            HttpResponseMessage response;
            try
            {

                using var httpClient = new HttpClient();
                response= await httpClient.SendAsync(httpRequest);
            }
            catch (Exception ex)
            {
                var errorMessage = "Rest error: || Application Error: " + ex.Message;
                throw new Exception(errorMessage);
            }
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    result = JsonConvert.DeserializeObject<T>(apiResponse);
                }
                catch (Exception ex)
                {
                   var errorMessage = "Error: while deserializing response: " + ex.Message;
                    throw new Exception(errorMessage);
                }
            }

            return result;
        }
    }
}
