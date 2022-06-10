using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIClient
{
    public static class ServiceProviderExtension
    {
        public static IServiceCollection RegisterClients(this IServiceCollection container)
        {
            container.AddHttpClient();
            container.AddScoped<INovelClient, NovelClient>();
            container.AddScoped<IMagazineClient, MagazineClient>();
            container.AddScoped<IPictureBookClient, PictureBookClient>();
            container.AddScoped<ICustomerClient, CustomerClient>();
            container.AddScoped<ILibraryClient, LibraryClient>();
            container.AddScoped<IReservationClient, ReservationClient>();

            

            return container;
        }
    }
}
