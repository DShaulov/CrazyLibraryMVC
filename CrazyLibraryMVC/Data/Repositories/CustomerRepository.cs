using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;

namespace CrazyLibraryMVC.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext m_DbContext;
        public CustomerRepository(DatabaseContext dbContext)
        {
            m_DbContext = dbContext;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            string sql = File.ReadAllText("Sql/Customers/InsertCustomer.sql");
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, customer);
            }
        }

        Task<int> ICustomerRepository.InsertCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
