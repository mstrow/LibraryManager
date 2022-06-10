
namespace DataAccessLayer.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int BookID { get; set; }

        public int LibraryID { get; set; }

        public virtual Library Library { get; set; }

        public DateTime Date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Book Book { get; set; }
    }
}
