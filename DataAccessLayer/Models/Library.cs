

namespace DataAccessLayer.Models
{
    public class Library
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public Library()
        {
            Books = new HashSet<Book>();
            Customers = new HashSet<Customer>();
            Reservations = new HashSet<Reservation>();
        }

    }
}
