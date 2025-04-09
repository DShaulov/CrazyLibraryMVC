using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrazyLibraryMVC.Models
{
    public class BookHistory
    {
        public int Id { get; set; } // Auto generated
        public required string BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
