using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class LibraryModel : ILibraryModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("books")]
        public IList<IBookModel> Books { get; set; }

        [JsonPropertyName("customers")]
        public IList<ICustomerModel> Customers { get; set; }

        [JsonPropertyName("reservations")]
        public IList<IReservationModel> Reservations { get; set; }

        public LibraryModel()
        {
            Books = new List<IBookModel>();
            Customers = new List<ICustomerModel>();
            Reservations = new List<IReservationModel>();
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
