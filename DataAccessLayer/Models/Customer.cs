
namespace DataAccessLayer.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public int LibraryID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public virtual Library Library { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public Customer()
        {
            Reservations = new HashSet<Reservation>();
        }
    }


}
