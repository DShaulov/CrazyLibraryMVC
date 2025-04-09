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

        public async Task<int?> GetAuthorIdAsync(Author author)
        {
            string sql = File.ReadAllText("Sql/Authors/CheckExistingAuthor.sql");
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<int?>(sql, author);
                return result;
            }
        }

        public async Task<int> InsertAuthorAsync(Author author)
        {
            int? existingAuthorId = await GetAuthorIdAsync(author);
            if (existingAuthorId == null)
            {
                string sql = File.ReadAllText("Sql/Authors/InsertAuthor.sql");
                using (IDbConnection connection = m_DbContext.CreateConnection())
                {
                    int authorId = await connection.ExecuteScalarAsync<int>(sql, author);
                    return authorId;
                }
            }
            else
            {
                return (int) existingAuthorId;
            }
            
        }
    }
}
