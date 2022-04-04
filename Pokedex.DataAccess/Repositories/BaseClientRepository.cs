﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.DataAccess.Repositories
{
    public abstract class BaseClientRepository
    {
        /// <summary>
        /// Base repository method for all API requests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        protected static async Task<T> SendRequest<T>(HttpRequestMessage httpRequest) where T : new()
        {
            T result = default;
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
