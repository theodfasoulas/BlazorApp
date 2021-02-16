using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class BaseCustomerList : ComponentBase
    {
        [Inject]
        public ICustomerRepository _customerRepository { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public List<CustomerViewModel> Customers { get; set; } = new List<CustomerViewModel>();

        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public int TotalPages { get; set; } = 0;

        private async Task LoadCustomers()
        {
            var list = await _customerRepository.LoadCustomersWithPagingAsync(new Shared.PagingParameters() { PageNumber = CurrentPage , PageSize = PageSize});
            this.Customers = list.Items;
            this.TotalPages = list.TotalPages;
            this.CurrentPage = list.CurrentPage;
            

        }
        protected override async Task OnInitializedAsync()
        {
            await LoadCustomers();
            await base.OnInitializedAsync();
        }
        protected async Task UpdateList(int pageNumber)
        {
          
            var list = await _customerRepository.LoadCustomersWithPagingAsync(new Shared.PagingParameters() { PageNumber = pageNumber, PageSize = PageSize });
            this.Customers = list.Items;
            TotalPages = list.TotalPages;
            CurrentPage = pageNumber;
        }
    }
}
