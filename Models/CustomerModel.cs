using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class CustomerModel : ICustomerModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("libraryId")]
        public int LibraryID { get; set; }

        [Required]
        [StringLength(128)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        [StringLength(25)]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("reservations")]
        public IList<IReservationModel> Reservations { get; set; }

        public CustomerModel()
        {
            Reservations = new List<IReservationModel>();
        }
        public override string ToString()
        {
            return Name;
        }
    }



}
