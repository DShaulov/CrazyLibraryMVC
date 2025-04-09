using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace CrazyLibraryMVC.Data.Repositories
{
    public class BookHistoryRepository : IBookHistoryRepository
    {
        private readonly DatabaseContext m_DbContext;

        public BookHistoryRepository(DatabaseContext context)
        {
            m_DbContext = context;
        }

        public async Task InsertBookHistoryAsync(BookHistory bookHistory)
        {
            // If the book history describes a borrowing, create a new record
            if (bookHistory.BorrowDate != null) 
            {
                using (IDbConnection connection = m_DbContext.CreateConnection())
                {
                    await connection.InsertAsync<BookHistory>(bookHistory);
                }
            }
            // If the book history describes a returning, update the borrowing record
            else
            {
                BookHistory? existingBookHistory = await GetBookHistoryByCustomerAndBookIds(bookHistory.BookId,
                    bookHistory.CustomerId);
                if (existingBookHistory != null)
                {
                    existingBookHistory.ReturnDate = bookHistory.ReturnDate;
                    using (IDbConnection connection = m_DbContext.CreateConnection())
                    {
                        await connection.UpdateAsync<BookHistory>(existingBookHistory);
                    }
                }
                else
                {
                    throw new Exception("Bookhistory record not found");
                }
                
            }
        }

        private async Task<BookHistory?> GetBookHistoryByCustomerAndBookIds(string bookId, int customerId)
        {
            string sql = File.ReadAllText("Sql/BookHistories/GetBookHistoryByCustomerAndBookIds.sql");
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                var parameters = new { BookId = bookId , CustomerId = customerId};
                BookHistory? result = await connection.QueryFirstOrDefaultAsync<BookHistory?>(sql, parameters);
                return result;
            }
        }
    }
}
