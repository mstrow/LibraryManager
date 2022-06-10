using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestAPIClient;
using TestConsoleAppOnline;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        Console.WriteLine(Directory.GetCurrentDirectory());
        var configuration = builder.Build();

        var serviceProvider = new ServiceCollection()
            .Configure<ApiConfiguration>(configuration.GetSection("ApiConfiguration"))
            .AddSingleton<IApiConfiguration>(x => x.GetRequiredService<IOptions<ApiConfiguration>>().Value)
            .AddSingleton<IConsoleApplication, ConsoleApplication>()
            .RegisterClients()
            .BuildServiceProvider();

        IServiceScope scope = serviceProvider.CreateScope();
        scope.ServiceProvider.GetRequiredService<IConsoleApplication>().Run();

        if (serviceProvider is IDisposable)
        {
            serviceProvider.Dispose();
        }
    }
}