using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;

namespace CrazyLibraryMVC.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext m_DbContext;
        public BookRepository(DatabaseContext dbContext) 
        {
            m_DbContext = dbContext;
        }

        public async Task InsertBookAsync(Book book)
        {
            string sql = File.ReadAllText("Sql/Books/InsertBook.sql");
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, book);
            }
        }
    }
}
