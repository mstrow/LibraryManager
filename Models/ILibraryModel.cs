namespace Models
{
    public interface ILibraryModel
    {
        IList<IBookModel> Books { get; set; }
        IList<ICustomerModel> Customers { get; set; }
        int ID { get; set; }
        string Location { get; set; }
        string Name { get; set; }
        IList<IReservationModel> Reservations { get; set; }

        string ToString();
    }
}