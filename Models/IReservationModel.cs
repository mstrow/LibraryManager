namespace Models
{
    public interface IReservationModel
    {
        int BookID { get; set; }
        int CustomerID { get; set; }
        int LibraryID { get; set; }
        DateTime Date { get; set; }
        int ID { get; set; }
    }
}