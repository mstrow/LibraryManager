using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class PictureBookModel : BookModel
    {

        [JsonPropertyName("size")]
        public string? Size { get; set; }

    }
}
