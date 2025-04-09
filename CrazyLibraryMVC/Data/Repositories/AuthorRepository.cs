using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;

namespace CrazyLibraryMVC.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DatabaseContext m_DbContext;

        public AuthorRepository(DatabaseContext dbContext)
        {
            m_DbContext = dbContext;
        }

        public async Task InsertAuthorAsync(Author author)
        {
            string sql = File.ReadAllText("Sql/Customers/InsertAuthor.sql");
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, author);
            }
        }
    }
}
