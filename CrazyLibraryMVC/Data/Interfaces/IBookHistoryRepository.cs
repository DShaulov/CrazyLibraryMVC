using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Data.Interfaces
{
    public interface IBookHistoryRepository
    {
        Task InsertBookHistoryAsync(BookHistory bookHistory);
    }
}
