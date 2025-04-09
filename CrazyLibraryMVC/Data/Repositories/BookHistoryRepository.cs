using System.Data;
using CrazyLibraryMVC.Data.Interfaces;
using CrazyLibraryMVC.Models;
using Dapper;

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
            string sql = File.ReadAllText("Sql/Customers/InsertBookHistory.sql");
            using (IDbConnection connection = m_DbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, bookHistory);
            }
        }
    }
}
