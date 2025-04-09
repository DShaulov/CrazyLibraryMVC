using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrazyLibraryMVC.Models
{
    public class Book
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Image_url { get; set; }
        public required string LibraryCallNumber { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesAvailable { get; set; }
        public int BorrowCount { get; set; }
    }
}
