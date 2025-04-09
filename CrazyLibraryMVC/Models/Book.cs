using Dapper.Contrib.Extensions;


namespace CrazyLibraryMVC.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int AuthorId { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Image_url { get; set; }
        public required string LibraryCallNumber { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesAvailable { get; set; }
        public int BorrowCount { get; set; }
    }
}
