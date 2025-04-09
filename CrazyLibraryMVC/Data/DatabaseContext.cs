using System.Data;
using MySql.Data.MySqlClient;

namespace CrazyLibraryMVC.Data
{
    public class DatabaseContext
    {
        private readonly IConfiguration m_Configuration;
        private readonly string m_ConnectionString;

        public DatabaseContext(IConfiguration configuration)
        {
            m_Configuration = configuration;
            string? connectionString = m_Configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                m_ConnectionString = connectionString;
            }
            else
            {
                throw new InvalidOperationException("Connection string cannot be null.");
            }

        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(m_ConnectionString);
        }
    }
}
