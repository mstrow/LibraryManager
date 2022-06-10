using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using RestAPIClient;
namespace LibraryMAUIApp
{
    public partial class App : Application
    {
        public static IApiConfiguration Configuration;
        public App()
        {
            WriteTextFileToCache("appsettings.json");
            var builder = new ConfigurationBuilder()
            .SetBasePath(FileSystem.CacheDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            Configuration = configuration.GetSection("ApiConfiguration").Get<ApiConfiguration>();

            InitializeComponent();

            MainPage = new AppShell();
        }
        private async Task<string> ReadTextFile(string filePath)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
            using StreamReader reader = new StreamReader(fileStream);

            return await reader.ReadToEndAsync();
        }
        private async void WriteTextFileToCache(string fileName)
        {
            var file = await ReadTextFile(fileName);
            string destPath = Path.Combine(FileSystem.CacheDirectory, fileName);
            await File.WriteAllTextAsync(destPath, file);
        }
    }
}