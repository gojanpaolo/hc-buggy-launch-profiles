using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Foo
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(ConfigureWebHost);

        private static void ConfigureWebHost(IWebHostBuilder webBuilder) =>
            webBuilder
               .UseSetting("ServiceName", GetProjectName())
               .UseStartup<Startup>();

        private static string GetProjectName() => Assembly.GetExecutingAssembly().GetName().Name;
    }
}
