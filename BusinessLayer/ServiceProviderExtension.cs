using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class ServiceProviderExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection container)
        {
            container.AddScoped<INovelService, NovelService>();
            container.AddScoped<IPictureBookService, PictureBookService>();
            container.AddScoped<IMagazineService, MagazineService>();
            container.AddScoped<ILibraryService, LibraryService>();
            container.AddScoped<IReservationService, ReservationService>();
            container.AddScoped<ICustomerService, CustomerService>();

            return container;
        }
    }
}
