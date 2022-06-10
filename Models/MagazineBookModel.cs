using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class MagazineBookModel : BookModel
    {
        [JsonPropertyName("issueDate")]
        public DateTime? IssueDate { get; set; }
    }
}
