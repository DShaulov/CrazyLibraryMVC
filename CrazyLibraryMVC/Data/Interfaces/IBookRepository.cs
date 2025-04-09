using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Data.Interfaces
{
    public interface IBookRepository
    {
        Task InsertBookAsync(Book book);
        Task<Book?> GetBookByIdAsync(int id);
    }
}
