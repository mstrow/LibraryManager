using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer
{
    public static class ServiceProviderExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection container)
        {
            container.AddScoped<ITransaction, Transaction>();
            container.AddScoped<ILibraryRepository, LibraryRepository>();
            container.AddScoped<IBookRepository, BookRepository>();
            container.AddScoped<IReservationRepository, ReservationRepository>();

            return container;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection container, string connectionString)
        {

            container.AddDbContext<ModelContext>(options => options.UseMySQL(connectionString, MySQLOptionsAction: sqloptions =>
            {
                sqloptions.CommandTimeout(20);
            }));

            return container;
        }
    }
}