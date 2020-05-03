namespace Org.Domain.Abstractions.Business
{
    using FluentValidation;
    using IocServiceStack;
 
    using Entities;

    [Contract]
    public interface ICustomerValidator : IValidator<CustomerEntity>
    {
        
    }
}
