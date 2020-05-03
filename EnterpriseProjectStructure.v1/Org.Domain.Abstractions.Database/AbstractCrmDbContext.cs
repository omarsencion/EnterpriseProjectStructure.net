namespace Org.Domain.Abstractions.Database
{
    using IocServiceStack;
    using Microsoft.EntityFrameworkCore;

    using Entities;

    [Contract]
    public  abstract class AbstractCrmDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
