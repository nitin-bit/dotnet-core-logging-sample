using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace LoggingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureLogging(f => f.AddConsole(LogLevel.Debug)) // initialize logging here to make the logger available in Startup.cs
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
