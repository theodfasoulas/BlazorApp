using BlazorApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(CustomerViewModel customerViewModel);
        Task<bool> DeleteCustomerAsync(string id);
        Task<CustomerViewModel> GetCustomerAsync(string id);
        Task<IEnumerable<CustomerViewModel>> LoadCustomersAsync();
        Task UpdateCustomerAsync(string id, CustomerViewModel customerViewModel);

        Task<CustomerList> LoadCustomersWithPagingAsync(PagingParameters pagingParameters);
    }
}