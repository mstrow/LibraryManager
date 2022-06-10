using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;
using Models;
using AutoMapper;
using System.Collections;

namespace BusinessLayer
{
    public class LibraryService : BaseService, ILibraryService
    {

        public LibraryService(ITransaction unitOfWork) : base(unitOfWork)
        {
        }

        public LibraryModel Get(int id)
        {
            //Get the library
            var library = UnitOfWork.Libraries.Get(id);

            //Create the configuration that thells AutoMapper the classes to map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Library, LibraryModel>();
                cfg.CreateMap<Library, ILibraryModel>().As<LibraryModel>();
                cfg.CreateMap<Customer, CustomerModel>();
                cfg.CreateMap<Reservation, ReservationModel>()
                        .ForMember(x => x.Library, opt => opt.Ignore())
                        .ForMember(x => x.Customer, opt => opt.Ignore());
                cfg.CreateMap<Reservation, IReservationModel>().As<ReservationModel>();
                cfg.CreateMap<Magazine, MagazineBookModel>();
                cfg.CreateMap<Novel, NovelBookModel>();
                cfg.CreateMap<PictureBook, PictureBookModel>();
                cfg.CreateMap<Magazine, IBookModel>().As<MagazineBookModel>();
                cfg.CreateMap<PictureBook, IBookModel>().As<PictureBookModel>();
                cfg.CreateMap<Novel, IBookModel>().As<NovelBookModel>();
            });

            //Create the mapper
            IMapper mapper = new Mapper(config);

            //Create the model to map the library entity to
            var model = new LibraryModel();

            //Do the mapping
            mapper.Map(library, model);

            return model;
        }
        public int Add(LibraryModel library)
        {
            Validate(library);

            //Ignore the as we are just adding the library
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LibraryModel, Library>()
                                                 .ForMember(x => x.Books, opt => opt.Ignore())
                                                 .ForMember(x => x.Customers, opt => opt.Ignore())
                                                 .ForMember(x => x.Reservations, opt => opt.Ignore()));

            IMapper mapper = new Mapper(config);

            var data = new Library();

            mapper.Map(library, data);

            //Add the library to the repository and save
            UnitOfWork.Libraries.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        public int Update(LibraryModel model)
        {
            Validate(model);

            //Ignore the as we are just updating the library
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LibraryModel, Library>()
            .ForMember(x => x.Books, opt => opt.Ignore())
            .ForMember(x => x.Reservations, opt => opt.Ignore())
            .ForMember(x => x.Customers, opt => opt.Ignore()));

            IMapper mapper = new Mapper(config);

            //Retrive the library to update
            var data = UnitOfWork.Libraries.Get(model.ID);

            //Map the model to the enitity
            mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.Libraries.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }
        public void Delete(int id)
        {
            UnitOfWork.Libraries.Delete(id);
            UnitOfWork.Save();
        }
        public IList<LibraryModel> List()
        {
            var libraries = UnitOfWork.Libraries.List();

            //Configure the mappings for all the classes AutoMapper may come across.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Library, LibraryModel>();
                cfg.CreateMap<Library, ILibraryModel>().As<LibraryModel>();
                cfg.CreateMap<Customer, CustomerModel>();
                cfg.CreateMap<Reservation, ReservationModel>()
                        .ForMember(x => x.Library, opt => opt.Ignore())
                        .ForMember(x => x.Customer, opt => opt.Ignore());
                cfg.CreateMap<Reservation, IReservationModel>().As<ReservationModel>();
                cfg.CreateMap<Magazine, MagazineBookModel>();
                cfg.CreateMap<Novel, NovelBookModel>();
                cfg.CreateMap<PictureBook, PictureBookModel>();
                cfg.CreateMap<Magazine, IBookModel>().As<MagazineBookModel>();
                cfg.CreateMap<PictureBook, IBookModel>().As<PictureBookModel>();
                cfg.CreateMap<Novel, IBookModel>().As<NovelBookModel>();
            });

            IMapper mapper = new Mapper(config);

            //Create the model list
            var models = new List<LibraryModel>();

            //AutoMapper maps the classes and added the models to the list
            mapper.Map(libraries, models);

            return models;
        }
        public IEnumerable ListNames()
        {
            //ListNames return an anonymous class so doesn't need to be mapped
            return UnitOfWork.Libraries.List();
        }
    }
}
