using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public interface IDbContext
    {
        Task DeleteRecordAsync<T>(string table, string id);
        Task InsertRecordAsync<T>(string table, T record);
        Task<T> LoadRecordByIdAsync<T>(string table, string id);
        Task<IEnumerable<T>> LoadRecordsAsync<T>(string table);
        Task<PagedList<T>> LoadRecordsWithPagingAsync<T>(string table,int pageSize,int pageNumber);
        Task UpsertRecordAsync<T>(string table, string id, T record);
    }
}