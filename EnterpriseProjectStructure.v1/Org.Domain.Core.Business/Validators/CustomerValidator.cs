namespace Org.Domain.Core.Business.Validators
{
    using FluentValidation;
    using IocServiceStack;

    using Entities;
    using Abstractions.Business;

    [Service]
    public class CustomerValidator : AbstractValidator<CustomerEntity>, ICustomerValidator
    {
        public const string InsertRuleset = "Insert";
        public const string UpdateRuleset = "Update";

        public CustomerValidator()
        {
            RuleSet(InsertRuleset, () =>
            {
                RuleSetForSave();
            });

            RuleSet(UpdateRuleset, () =>
            {
                RuleFor(customer => customer.Id)
                    .GreaterThan(0)
                        .WithMessage("Invalid Customer Id");
                RuleSetForSave();
            });
        }

        private void RuleSetForSave()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty();

            RuleFor(customer => customer.LastName)
                .NotEmpty();

            RuleFor(customer => customer.City)
                .NotEmpty();
                    //.Length(10)
                    //    .Matches("^[0-9]*$");
        }
    }
}
