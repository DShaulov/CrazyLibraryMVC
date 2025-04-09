using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task InsertCustomerAsync(Customer customer);
    }
}
