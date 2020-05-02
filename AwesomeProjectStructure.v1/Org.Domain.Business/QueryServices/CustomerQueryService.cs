namespace Org.Domain.Business
{
    using System;
    using System.Collections.Generic;
    using IocServiceStack;

    using Abstractions.Business;
    using Abstractions.Data;
    using Entities;

    [Service]
    public sealed class CustomerQueryService : ICustomerQuery
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerQueryService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentException(nameof(customerRepository));
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }

        public CustomerEntity GetCustomerById(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }

        public IList<CustomerEntity> GetCustomers()
        {
            return new List<CustomerEntity> {
                new CustomerEntity
                {
                    FirstName = "TEST"
                }
            };
            // return _customerRepository.GetCustomers();
        }

    }
}
