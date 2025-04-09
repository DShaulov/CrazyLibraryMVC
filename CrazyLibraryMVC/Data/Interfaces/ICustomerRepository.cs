using CrazyLibraryMVC.Models;

namespace CrazyLibraryMVC.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> InsertCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}
