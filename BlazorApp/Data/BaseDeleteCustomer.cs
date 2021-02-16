using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class BaseDeleteCustomer : ComponentBase
    {
        [Inject]
        public ICustomerRepository _customerRepository { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public string customerId { get; set; }

        protected string Title = "Delete";

        protected override Task OnInitializedAsync()
        {
            _customerRepository.DeleteCustomerAsync(customerId);
            navigationManager.NavigateTo("/customerList");
    
            return base.OnInitializedAsync();
        }
        public CustomerViewModel customer = new CustomerViewModel();
        public async Task DeleteCustomer(string customerId)
        {
            await _customerRepository.DeleteCustomerAsync(customerId);
            navigationManager.NavigateTo("/customerList");
        }
    }
}
