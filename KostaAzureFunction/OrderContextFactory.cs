using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KostaAzureFunction
{
    public class OrderContextFactory: IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContextFactory()
        {
        }

        public OrderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
            return new OrderContext(optionsBuilder.Options);
        }
    }
}
