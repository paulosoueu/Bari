using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BancoBari.Job
{
    public class Program
    {
        public static void Main (string[] args)
        {
            CreateWebHostBuilder(args);
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
