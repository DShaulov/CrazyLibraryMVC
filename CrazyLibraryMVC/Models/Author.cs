using Dapper.Contrib.Extensions;

namespace CrazyLibraryMVC.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int? Id { get; set; } // Auto generated
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
