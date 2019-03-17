using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using SimpleCLI.ConfigExtensions;
using System;

namespace SimpleCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            Configure(serviceProvider);

            var app = serviceProvider.GetRequiredService<MaCLI>();
            try
            {
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
                app.ShowHelp();
            }
        }
        
        static void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureData();
            services.AddScoped<MaCLI>();
        }

        static void Configure(ServiceProvider serviceProvider)
        {
            serviceProvider.FeedData();
        }
    }
}
