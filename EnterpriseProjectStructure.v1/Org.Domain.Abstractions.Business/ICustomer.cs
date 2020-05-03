namespace Org.Domain.Abstractions.Business
{
    using System;
    using IocServiceStack;
    using Models;

    [Contract]
    public interface ICustomer : IDisposable
    {
        void Create(CustomerData customer);
        void Update(CustomerData customer);
        void Delete(int customerId);
        //Test Purpose
        string Validate(CustomerData customer);
    }
}
