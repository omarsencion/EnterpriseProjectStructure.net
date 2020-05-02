namespace Org.Domain.Abstractions.Data
{
    using System.Collections.Generic;
    using IocServiceStack;

    using Entities;
    using DataBridge;

    [Contract]
    public interface ICustomerRepository : IBaseRepository<CustomerEntity>
    {
        IList<CustomerEntity> GetCustomers();
        CustomerEntity GetCustomerById(int customerId);
    }
}
