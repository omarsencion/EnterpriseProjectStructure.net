namespace Org.Domain.Abstractions.Business
{
    using System;
    using System.Collections.Generic;
    using IocServiceStack;

    using Entities;

    [Contract]
    public interface ICustomerQuery : IDisposable
    {
        IList<CustomerEntity> GetCustomers();
        CustomerEntity GetCustomerById(int customerId);
    }
}
