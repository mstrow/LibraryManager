using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Transaction : IDisposable, ITransaction
    {
        private readonly ModelContext _context;
        private ILibraryRepository _libraryRepository;
        private IBookRepository _bookRepository;
        private IReservationRepository _reservationRepository;
        private ICustomerRepository _customerRepository;
        private bool _disposed = false;


        public Transaction(ModelContext context)
        {
            _context = context;
        }

        public ILibraryRepository Libraries
        {
            get
            {
                if (_libraryRepository == null)
                {
                    _libraryRepository = new LibraryRepository(_context);
                }
                return _libraryRepository;
            }
        }
        public IBookRepository Books
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_context);
                }
                return _bookRepository;
            }
        }

        public IReservationRepository Reservations
        {
            get
            {
                if (_reservationRepository == null)
                {
                    _reservationRepository = new ReservationRepository(_context);
                }
                return _reservationRepository;
            }
        }
        public ICustomerRepository Customers
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_context);
                }
                return _customerRepository;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing) { _context.Dispose(); }
            }
            this._disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}