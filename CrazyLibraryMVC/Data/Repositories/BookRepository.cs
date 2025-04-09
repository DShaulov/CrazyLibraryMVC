using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;
using Dapper.Contrib.Extensions;

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
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                Book? existingBook = await connection.GetAsync<Book>(book.Id);
                if (existingBook == null) 
                { 
                    await connection.InsertAsync(book);
                }
            }
        }
    }
}
