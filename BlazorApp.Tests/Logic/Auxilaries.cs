using AutoMapper;
using BlazorApp.Models;
using System.Collections.Generic;

namespace BlazorApp.Tests
{
    public static class Auxilaries
    {
        public static IMapper GenerateMapper()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddMaps(new[]
                {
                    typeof(CustomerProfile)
                });
            });
            return config.CreateMapper();
        }
        public static IEnumerable<CustomerViewModel> GenerateCustomers()
        {
            return new List<CustomerViewModel>
            {
                new CustomerViewModel()
                {
                    ContactName = "Theodoros Fasoulas",
                    CompanyName = "Epsilon",
                    City = "Thessaloniki",
                },
                new CustomerViewModel()
                {
                    ContactName = "Theodoros Fasoulas",
                    CompanyName = "Epsilon",
                    City = "Thessaloniki",
                },
                new CustomerViewModel()
                {
                    ContactName = "Theodoros Fasoulas",
                    CompanyName = "Epsilon",
                    City = "Thessaloniki",
                },
            };

        }

        public static CustomerList GenerateCustomersList()
        {
            return new CustomerList()
            {
                CurrentPage = 1,
                PageSize = 10,
                TotalCount = 200,
                TotalPages = 20,
                Items = new List<CustomerViewModel>
                {
                    new CustomerViewModel()
                    {
                        ContactName = "Theodoros Fasoulas",
                        CompanyName = "Epsilon",
                        City = "Thessaloniki",
                    },
                    new CustomerViewModel()
                    {
                        ContactName = "Theodoros Fasoulas",
                        CompanyName = "Epsilon",
                        City = "Thessaloniki",
                    },
                    new CustomerViewModel()
                    {
                        ContactName = "Theodoros Fasoulas",
                        CompanyName = "Epsilon",
                        City = "Thessaloniki",
                    },
                },
            };

        }
    }
}
