using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace CrazyLibraryMVC.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext m_DbContext;
        public CustomerRepository(DatabaseContext dbContext)
        {
            m_DbContext = dbContext;
        }

        public async Task<int> InsertCustomerAsync(Customer customer)
        {
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                Customer? existingCustomer = await GetCustomerByPassport(customer.Passport);
                if (existingCustomer != null)
                {
                    int customerId = await connection.InsertAsync<Customer>(customer);
                    return customerId;
                }
                else
                {
                    return existingCustomer.Id;
                }
            }
        }

        /// <summary>
        /// Retrieves a customer record by its passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns>If found, return the customer - otherwise return null</returns>
        public async Task<Customer?> GetCustomerByPassport(string passport)
        {
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                string sql = File.ReadAllText("Sql/Customers/GetCustomerByPassport.sql");
                var parameters = new { Passport = passport };
                Customer? customer = await connection.QuerySingleOrDefaultAsync<Customer>(sql, parameters);
                return customer;
            }
        }
    }
}
