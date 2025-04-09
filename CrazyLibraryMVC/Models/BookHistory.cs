using Dapper.Contrib.Extensions;


namespace CrazyLibraryMVC.Models
{
    [Table("BookHistories")]
    public class BookHistory
    {
        [Key]
        public int Id { get; set; } // Auto generated
        public required string BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
