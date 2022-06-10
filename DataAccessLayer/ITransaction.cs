namespace DataAccessLayer
{
    public interface ITransaction
    {
        ILibraryRepository Libraries { get; }
        IBookRepository Books { get; }
        IReservationRepository Reservations { get; }
        ICustomerRepository Customers { get; }

        void Dispose();
        void Save();
    }
}