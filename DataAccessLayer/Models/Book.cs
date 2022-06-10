using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Book
    {
        public int ID { get; set; }

        public int LibraryID { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime LastModified { get; set; }

        public virtual Library Library { get; set; }


        public Book()
        {
            Reservations = new HashSet<Reservation>();
        }
    }
}
