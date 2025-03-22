using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acreddi.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AcreddiDbContextFactory : IDesignTimeDbContextFactory<AcreddiDbContext>
{
    public AcreddiDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AcreddiEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AcreddiDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new AcreddiDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Acreddi.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
