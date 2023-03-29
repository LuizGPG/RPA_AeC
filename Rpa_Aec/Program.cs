using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Rpa_Aec
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
               .UseDefaultServiceProvider(options => { })
               .Build()
               .Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
