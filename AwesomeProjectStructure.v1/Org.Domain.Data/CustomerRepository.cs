namespace Org.Domain.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using IocServiceStack;

    using Entities;
    using Abstractions.Data;
    using Abstractions.Database;

    [Service]
    public sealed class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(AbstractCrmDbContext abstractCrmDbContext) : base(abstractCrmDbContext)
        {

        }

        public IList<CustomerEntity> GetCustomers()
        {
            var query = from customer in DbContext.Customers
                        select customer;

            return query.ToList();
        }

        public CustomerEntity GetCustomerById(int customerId)
        {
            var query = from customer in DbContext.Customers
                        where customer.Id == customerId
                        select customer;

            return query.SingleOrDefault();
        }
    }
}
