
namespace ClientSpecificExtension
{

    using FluentValidation;
    using IocServiceStack;

    using Org.Domain.Abstractions.Business;
    using Org.Domain.Entities;

    [Service]
    public class XyzCustomerValidator : AbstractValidator<CustomerEntity>, ICustomerValidator
    {
        public const string InsertRuleset = "Insert";
        public const string UpdateRuleset = "Update";

        public XyzCustomerValidator()
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

            // Remove city as mandatory for this customer
            //RuleFor(customer => customer.City)
            //    .NotEmpty();
            //.Length(10)
            //    .Matches("^[0-9]*$");
        }
    }
}
