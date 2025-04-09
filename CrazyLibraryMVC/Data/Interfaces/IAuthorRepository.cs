using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Data.Interfaces
{
    public interface IAuthorRepository
    {
        Task InsertAuthorAsync(Author author);
    }
}
