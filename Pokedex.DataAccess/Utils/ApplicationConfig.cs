using Microsoft.Extensions.Configuration;

namespace Pokedex.Client.Utils
{
    public static class ApplicationConfig
    {
        public static IConfiguration Config { get; set; }
        public static string ApplicationEnv => Config["ApplicationEnvironment"];
        public static string PokeApiUrl => Config[ApplicationEnv+":pokeApiUrl"];
        public static string ShakespeareApiUrl => Config[ApplicationEnv+":shakespeareApiUrl"];
        public static string YodaApiUrl => Config[ApplicationEnv+":yodaApiUrl"];
    }
}
