using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrazyLibraryMVC.Models
{
    public class Author
    {
        public int? Id { get; set; } // Auto generated
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
