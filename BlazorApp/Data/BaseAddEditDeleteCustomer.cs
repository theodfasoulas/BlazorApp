using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class BaseAddEditCustomer : ComponentBase
    {
        [Inject]
        public ICustomerRepository _customerRepository { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public string customerId { get; set; }

        protected string Title = "Add";

        protected bool IsDelete { get; set; } = false;

        public CustomerViewModel customer = new CustomerViewModel();

        protected async Task AddOrUpdateCustomer()
        {
            if (customerId != null)
            {
                await _customerRepository.UpdateCustomerAsync(customerId, customer);
            }
            else
            {
                await _customerRepository.AddCustomerAsync(customer);
            }
            navigationManager.NavigateTo("/customerList");
        }
        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(customerId))
            {
                Title = "Edit";
                customer = await _customerRepository.GetCustomerAsync(customerId);
            }
        }
        protected void DeleteCustomer()
        {
            _customerRepository.DeleteCustomerAsync(customerId);
            navigationManager.NavigateTo("/customerList");
        }
        protected void Cancel()
        {
            navigationManager.NavigateTo("/customerList");
        }
    }
}
