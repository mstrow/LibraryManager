using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class ReservationModel : IReservationModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [Required]
        [JsonPropertyName("customerId")]
        public int CustomerID { get; set; }

        [Required]
        [JsonPropertyName("bookId")]
        public int BookID { get; set; }

        [Required]
        [JsonPropertyName("libraryId")]
        public int LibraryID { get; set; }

        [Required]
        [JsonPropertyName("dueDate")]
        public DateTime Date { get; set; }

        [JsonPropertyName("library")]
        public ILibraryModel? Library { get; set; }

        [JsonPropertyName("book")]
        public IBookModel? Book { get; set; }

        [JsonPropertyName("customer")]
        public ICustomerModel? Customer { get; set; }
    }
}
