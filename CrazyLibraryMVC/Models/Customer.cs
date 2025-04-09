using Dapper.Contrib.Extensions;

namespace CrazyLibraryMVC.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; } // Auto generated
        public required string Passport { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Zip { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
