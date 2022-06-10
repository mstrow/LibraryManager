using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class BookModel : IBookModel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("libraryId")]
        public int LibraryID { get; set; }

        [Required]
        [StringLength(13)]
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required]
        [StringLength(128)]
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [Required]
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("cost")]
        public decimal Cost { get; set; }

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        [Required]
        [JsonPropertyName("lastModified")]
        public DateTime LastModified { get; set; }

        public BookModel()
        {
            ImageUrl = "";
        }
        public override string ToString()
        {
            return string.Format("\"{0}\" By {1} ({2})", Title, Author, Year);
        }
    }
}
