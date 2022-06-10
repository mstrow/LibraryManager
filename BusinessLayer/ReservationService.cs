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
    public class ReservationService : BaseService, IReservationService
    {

        public ReservationService(ITransaction unitOfWork) : base(unitOfWork)
        {
        }

        public ReservationModel Get(int id)
        {
            //Get the reservation
            var reservation = UnitOfWork.Reservations.Get(id);

            //Create the configuration that thells AutoMapper the classes to map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Library, LibraryModel>();
                cfg.CreateMap<Customer, CustomerModel>().ForMember(x => x.Reservations, opt => opt.Ignore());
                cfg.CreateMap<Customer, ICustomerModel>().As<CustomerModel>();
                cfg.CreateMap<Reservation, ReservationModel>();
                cfg.CreateMap<Magazine, MagazineBookModel>();
                cfg.CreateMap<Novel, NovelBookModel>();
                cfg.CreateMap<PictureBook, PictureBookModel>();
                cfg.CreateMap<Magazine, IBookModel>().As<MagazineBookModel>();
                cfg.CreateMap<PictureBook, IBookModel>().As<PictureBookModel>();
                cfg.CreateMap<Novel, IBookModel>().As<NovelBookModel>();
            });

            //Create the mapper
            IMapper mapper = new Mapper(config);

            //Create the model to map the reservation entity to
            var model = new ReservationModel();

            //Do the mapping
            mapper.Map(reservation, model);

            return model;
        }
        public int Add(ReservationModel reservation)
        {
            Validate(reservation);

            //Ignore the as we are just adding the reservation
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReservationModel, Reservation>()
                                                 .ForMember(x => x.Customer, opt => opt.Ignore())
                                                 .ForMember(x => x.Book, opt => opt.Ignore())
                                                 .ForMember(x => x.Library, opt => opt.Ignore()));

            IMapper mapper = new Mapper(config);

            var data = new Reservation();

            mapper.Map(reservation, data);

            //Add the reservation to the repository and save
            UnitOfWork.Reservations.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        public int Update(ReservationModel model)
        {
            Validate(model);

            //Ignore the as we are just updating the reservation
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReservationModel, Reservation>()
                                                 .ForMember(x => x.Customer, opt => opt.Ignore())
                                                 .ForMember(x => x.Book, opt => opt.Ignore())
                                                 .ForMember(x => x.Library, opt => opt.Ignore()));

            IMapper mapper = new Mapper(config);

            //Retrive the reservation to update
            var data = UnitOfWork.Reservations.Get(model.ID);

            //Map the model to the enitity
            mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.Reservations.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }
        public void Delete(int id)
        {
            UnitOfWork.Reservations.Delete(id);
            UnitOfWork.Save();
        }
        public IList<ReservationModel> List()
        {
            var reservations = UnitOfWork.Reservations.List();

            //Configure the mappings for all the classes AutoMapper may come across.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Library, LibraryModel>();
                cfg.CreateMap<Customer, CustomerModel>().ForMember(x => x.Reservations, opt => opt.Ignore());
                cfg.CreateMap<Customer, ICustomerModel>().As<CustomerModel>();
                cfg.CreateMap<Reservation, ReservationModel>();
                cfg.CreateMap<Magazine, MagazineBookModel>();
                cfg.CreateMap<Novel, NovelBookModel>();
                cfg.CreateMap<PictureBook, PictureBookModel>();
                cfg.CreateMap<Magazine, IBookModel>().As<MagazineBookModel>();
                cfg.CreateMap<PictureBook, IBookModel>().As<PictureBookModel>();
                cfg.CreateMap<Novel, IBookModel>().As<NovelBookModel>();
            });

            IMapper mapper = new Mapper(config);

            //Create the model list
            var models = new List<ReservationModel>();

            //AutoMapper maps the classes and added the models to the list
            mapper.Map(reservations, models);

            return models;
        }
        public IEnumerable ListNames()
        {
            //ListNames return an anonymous class so doesn't need to be mapped
            return UnitOfWork.Reservations.List();
        }
    }
}
