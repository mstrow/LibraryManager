namespace Models
{
    public interface ICustomerModel
    {
        string Address { get; set; }
        int ID { get; set; }
        int LibraryID { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        IList<IReservationModel> Reservations { get; set; }

        string ToString();
    }
}