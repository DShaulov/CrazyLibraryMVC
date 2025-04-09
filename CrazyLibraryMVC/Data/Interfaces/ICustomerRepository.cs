using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> InsertCustomerAsync(Customer customer);
    }
}
