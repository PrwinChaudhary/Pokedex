using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Pokedex.Client.Utils;

namespace Pokedex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        ApplicationConfig.Config = hostContext.Configuration;
                    })
                    .UseStartup<Startup>();
                });
    }
}
