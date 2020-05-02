
namespace ClientSpecificExtension
{
    using Org.Domain.Abstractions.Business;
    using System;

    public class SpecialCustomer : ICustomer
    {
        public void Create(Org.Domain.Models.CustomerData customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int customerId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Update(Org.Domain.Models.CustomerData customer)
        {
            throw new NotImplementedException();
        }
    }
}
