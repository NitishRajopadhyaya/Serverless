using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly:FunctionsStartup(typeof(restAPIserverless.Startup))]
namespace restAPIserverless
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionStrings = Environment.GetEnvironmentVariable("ConnectionString");
            builder.Services.AddDbContext<AppDbContext>(options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionStrings));

            //builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Server= MYPAYDOTNET05\\\\SQL12;Database=Test;User Id=sa;Password=iamgreat@1234;Trusted_connection=True;TrustServerCertificate=True"));
        }
    }
}
 