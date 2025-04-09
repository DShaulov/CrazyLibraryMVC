using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Data.Interfaces
{
    public interface IAuthorRepository
    {
        Task<int> InsertAuthorAsync(Author author);
        Task<int?> GetAuthorIdAsync(Author author);
    }
}
