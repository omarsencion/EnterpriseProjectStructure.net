namespace Org.Domain.Business.Tests
{
    using System;
    using System.Collections.Generic;

    using Xunit;
    using AutoFixture;
    using AutoFixture.Xunit2;

    using FluentValidation;

    using Core.Data;
    using Core.Business;
    using SqlServerDatabase;
    using Core.Common;
    using Org.Domain.Models;
    using Org.Domain.Entities;
    using Org.Domain.Core.Business.Validators;

    public class CustomerServiceTests
    {
        public static IEnumerable<object[]> CustomerData
        {
            get
            {
                Fixture fixture = new Fixture();

                var completeCustomerData = fixture.Create<CustomerEntity>();
                return new List<object[]>
                {
                    new object[] {
                        new CustomerData() {
                            Customer = new CustomerEntity {
                                FirstName = "",
                                LastName = ""
                            }
                        },
                        false
                    },
                    new object[] {
                        new CustomerData() {
                            Customer = completeCustomerData
                        },
                        true
                    },
                };
            }
        }

        [Theory]
        [MemberData(nameof(CustomerData))]
        public void Create_Customer_ValidationErrors(CustomerData data, bool expected)
        {
            // Arrange
            var valdiator = new CustomerValidator();
            
            // Assert
            var result = valdiator.Validate(data.Customer, ruleSet: "Insert");

            // Assert
            Assert.Equal(expected, result.IsValid);
        }

        // Arrange
        //var settings = new Settings() { ConnectionString = "" };
        //var dbContext = new CrmDbContext(settings);
        //var customerRepository = new CustomerRepository(dbContext);


        //Act
        //using (var customerService = new CustomerService(
        //        customerRepository,
        //        ))
        //{

        //}

        //Assert

        //Cleanup
    }
}
