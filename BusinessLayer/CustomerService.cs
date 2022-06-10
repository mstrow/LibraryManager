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
    public class CustomerService : BaseService, ICustomerService
    {

        public CustomerService(ITransaction unitOfWork) : base(unitOfWork)
        {
        }
        public CustomerModel Get(int id)
        {
            //Get the customer
            var customer = UnitOfWork.Customers.Get(id);

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

            //Create the model to map the customer entity to
            var model = new CustomerModel();

            //Do the mapping
            mapper.Map(customer, model);

            return model;
        }
        public int Add(CustomerModel customer)
        {
            Validate(customer);

            //Ignore the as we are just adding the customer
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerModel, Customer>()
                                                 .ForMember(x => x.Library, opt => opt.Ignore()));

            IMapper mapper = new Mapper(config);

            var data = new Customer();

            mapper.Map(customer, data);

            //Add the customer to the repository and save
            UnitOfWork.Customers.Add(data);
            UnitOfWork.Save();

            return data.ID;
        }

        public int Update(CustomerModel model)
        {
            Validate(model);

            //Ignore the as we are just updating the customer
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerModel, Customer>()
                                                .ForMember(x => x.Library, opt => opt.Ignore()));

            IMapper mapper = new Mapper(config);

            //Retrive the customer to update
            var data = UnitOfWork.Customers.Get(model.ID);

            //Map the model to the enitity
            mapper.Map(model, data);

            //Update and save the 
            UnitOfWork.Customers.Update(data);
            UnitOfWork.Save();

            return data.ID;
        }
        public void Delete(int id)
        {
            UnitOfWork.Customers.Delete(id);
            UnitOfWork.Save();
        }
        public IList<CustomerModel> List()
        {
            var customers = UnitOfWork.Customers.List();

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
            var models = new List<CustomerModel>();

            //AutoMapper maps the classes and added the models to the list
            mapper.Map(customers, models);

            return models;
        }
        public IEnumerable ListNames()
        {
            //ListNames return an anonymous class so doesn't need to be mapped
            return UnitOfWork.Customers.List();
        }
    }
}
