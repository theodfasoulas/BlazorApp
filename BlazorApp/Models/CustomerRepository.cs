using AutoMapper;
using BlazorApp.Shared;
using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerRepository(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerViewModel>> LoadCustomersAsync()
        {
            try
            {
                List<CustomerViewModel> customers = new List<CustomerViewModel>();
                var records = await _dbContext.LoadRecordsAsync<CustomerDbModel>("Customers");
                foreach (var item in records)
                {
                    var viewModel = _mapper.Map<CustomerViewModel>(item);
                    customers.Add(viewModel);
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task AddCustomerAsync(CustomerViewModel customerViewModel)
        {
            try
            {
                var customer = _mapper.Map<CustomerDbModel>(customerViewModel);
                customer.Id = Guid.NewGuid().ToString();
                await _dbContext.InsertRecordAsync<CustomerDbModel>("Customers", customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task DeleteCustomerAsync(string id)
        {
            try
            {
                await _dbContext.DeleteRecordAsync<CustomerDbModel>("Customers", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task UpdateCustomerAsync(string id, CustomerViewModel customerViewModel)
        {
            try
            {
                var customer = _mapper.Map<CustomerDbModel>(customerViewModel);
                await _dbContext.UpsertRecordAsync<CustomerDbModel>("Customers", id, customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<CustomerViewModel> GetCustomerAsync(string id)
        {
            try
            {
                var customerDbModel = await _dbContext.LoadRecordByIdAsync<CustomerDbModel>("Customers", id);
                return _mapper.Map<CustomerViewModel>(customerDbModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<CustomerList> LoadCustomersWithPagingAsync(PagingParameters pagingParameters)
        {
            try
            {
                var dbResults = await _dbContext.LoadRecordsWithPagingAsync<CustomerDbModel>("Customers", pagingParameters.PageSize, pagingParameters.PageNumber);
                return _mapper.Map<PagedList<CustomerDbModel>, CustomerList>(dbResults);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
