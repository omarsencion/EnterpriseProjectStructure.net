namespace Org.Domain.Core.Business.Validators
{
    using FluentValidation;
    using IocServiceStack;
 
    using Entities;

    [Contract]
    public interface ICustomerValidator : IValidator<CustomerEntity>
    {
        
    }
}
