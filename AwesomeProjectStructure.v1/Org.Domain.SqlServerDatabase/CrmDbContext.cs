namespace Org.Domain.Database
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using IocServiceStack;

    using Entities;
    using Org.Domain.Abstractions.Database;
    using Org.Domain.Abstractions.Common;

    [Service]
    public class CrmDbContext : AbstractCrmDbContext
    {
        readonly ISettings _settings;
        public CrmDbContext(ISettings  settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>().ToTable("Customer");
        }
    }
}
