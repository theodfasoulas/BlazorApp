using BlazorApp.Controllers;
using BlazorApp.Models;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlazorApp.Tests
{
    public class CustomerRepositoryTests
    {

        [Fact]
        public async Task LoadCustomersIsSuccess()
        {
            //Arrange
            var viewRecords = Auxilaries.GenerateCustomers();
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo
                .Setup(x => x.LoadCustomersAsync()).Returns(Task.FromResult(viewRecords));

            //Act
            CustomerController customerController = new CustomerController(mockCustomerRepo.Object);
            var output = await customerController.LoadCustomers();

            var result = output.Result as OkObjectResult;
            var expectedRecords = result.Value as IEnumerable<CustomerViewModel>;

            //Assert
            NUnit.Framework.Assert.NotNull(output);
            Assert.Equal(viewRecords.Count(), expectedRecords.Count());
            mockCustomerRepo.VerifyAll();
        }
        [Fact]
        public async Task LoadCustomersWithPagingIsSuccess()
        {
            //Arrange
            var customerList = Auxilaries.GenerateCustomersList();
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo
                .Setup(x => x.LoadCustomersWithPagingAsync(It.IsAny<PagingParameters>())).Returns(Task.FromResult(customerList));

            //Act
            CustomerController customerController = new CustomerController(mockCustomerRepo.Object);
            var output = await customerController.LoadCustomersWithPaging(new PagingParameters());

            var result = output.Result as OkObjectResult;
            var expectedRecords = result.Value as CustomerList;

            //Assert
            NUnit.Framework.Assert.NotNull(output);
            Assert.Equal(1, expectedRecords.CurrentPage);
            Assert.Equal(200, expectedRecords.TotalCount);
            Assert.Equal(10, expectedRecords.PageSize);
            Assert.Equal(20, expectedRecords.TotalPages);
            mockCustomerRepo.VerifyAll();
        }
        [Fact]
        public async Task AddCustomerIsSuccessful()
        {
            var record = new CustomerViewModel()
            {
                ContactName = "Theodoros Fasoulas",
                CompanyName = "Epsilon",
                City = "Thessaloniki",
            };

            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo
                .Setup(x => x.AddCustomerAsync(record)).Returns(Task.FromResult(record));

            CustomerController customerController = new CustomerController(mockCustomerRepo.Object);
            var output = await customerController.AddCustomer(record);

            var result = output.Result as OkObjectResult;

            Assert.Equal(record,result.Value);

        }
        [Fact]
        public async Task DeleteCustomerIsSuccessful()
        {
            var record = new CustomerViewModel()
            {
                Id = Guid.NewGuid().ToString(),
                ContactName = "Theodoros Fasoulas",
                CompanyName = "Epsilon",
                City = "Thessaloniki",
            };

            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo
                .Setup(x => x.DeleteCustomerAsync(It.IsAny<string>())).Returns(Task.FromResult(true));

            CustomerController customerController = new CustomerController(mockCustomerRepo.Object);
            var output = await customerController.DeleteAsync(record.Id);

            var result = output.Result as OkObjectResult;

            Assert.Equal(true,result.Value);

        }
        [Fact]
        public async Task UpdateCustomerIsSuccessful()
        {
            var record = new CustomerViewModel()
            {
                Id = Guid.NewGuid().ToString(),
                ContactName = "Theodoros Fasoulas",
                CompanyName = "Epsilon",
                City = "Thessaloniki",
            };

            var mockCustomerRepo = new Mock<ICustomerRepository>();
            mockCustomerRepo
                .Setup(x => x.UpdateCustomerAsync(record.Id,record)).Returns(Task.FromResult(record));

            CustomerController customerController = new CustomerController(mockCustomerRepo.Object);
            var output = await customerController.Update(record);

            var result = output.Result as OkObjectResult;

            Assert.NotNull(result.Value);
            Assert.Equal(record, result.Value);

        }

    }
}
