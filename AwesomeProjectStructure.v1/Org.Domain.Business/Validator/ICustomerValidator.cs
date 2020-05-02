namespace Org.Domain.Business.Validator
{
    using FluentValidation;
    using IocServiceStack;
 
    using Entities;

    [Contract]
    public interface ICustomerValidator : IValidator<CustomerEntity>
    {
        
    }
}
