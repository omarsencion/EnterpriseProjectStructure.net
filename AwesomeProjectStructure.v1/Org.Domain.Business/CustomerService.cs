namespace Org.Domain.Business
{
    using System;
    using FluentValidation;
    using IocServiceStack;

    using Models;
    using Abstractions.Common;
    using Abstractions.Data;
    using Abstractions.Storage;
    using Abstractions.Business;
    using Validator;
 
    [Service]
    public sealed class CustomerService : ICustomer
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerValidator _customerValidator;
        private readonly IStorage _storage;
        private readonly ILogger _logger;

        public CustomerService(ICustomerRepository customerRepository,
                               [Internal]ICustomerValidator customerValidator,
                               IStorage storage,
                               ILogger logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _customerValidator = customerValidator ?? throw new ArgumentNullException(nameof(customerValidator));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }

        public void Create(CustomerData customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            //Validate the customer data
            _customerValidator.ValidateAndThrow(customer.Customer, CustomerValidator.InsertRuleset);

            //Save Customer
            _customerRepository.Insert(customer.Customer);
            _customerRepository.Save();

            //Save Customer Logo 
        }

        public void Update(CustomerData customer)
        {
            //Validate the customer data
            _customerValidator.ValidateAndThrow(customer.Customer, CustomerValidator.InsertRuleset);

            //Update Customer
            _customerRepository.Update(customer.Customer);
            _customerRepository.Save();

            //Update Customer Logo 
        }

        public void Delete(int customerId)
        {
            //Save Customer
            // _customerRepository.Delete(customerId);

            //Delete Customer Logo 
        }

        #region   Private Methods


        private void DeleteFiles(int customerId)
        {
                // 
        }

        private void SaveFiles(CustomerData customer)
        {
            
        }

        #endregion

    }
}
