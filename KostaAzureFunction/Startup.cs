using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

[assembly: FunctionsStartup(typeof(KostaAzureFunction.Startup))]

namespace KostaAzureFunction
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<OrderContext>(options => options.UseSqlServer(SqlConnection));
        }
    }
}