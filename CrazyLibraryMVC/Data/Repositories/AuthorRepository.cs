using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace CrazyLibraryMVC.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DatabaseContext m_DbContext;

        public AuthorRepository(DatabaseContext dbContext)
        {
            m_DbContext = dbContext;
        }

        /// <summary>
        /// Checks if an author already exists by matching their FirstName, LastName, and BirthDate.
        /// </summary>
        /// <param name="author"></param>
        /// <returns>The Id of the author or null if not found</returns>
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
                using (IDbConnection connection = m_DbContext.CreateConnection())
                {
                    int authorId = await connection.InsertAsync(author);
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
