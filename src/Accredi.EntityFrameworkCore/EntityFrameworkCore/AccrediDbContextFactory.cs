using System;
using System.IO;
using Accredi.Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Accredi.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AccrediDbContextFactory : IDesignTimeDbContextFactory<AccrediDbContext>
{
    public AccrediDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AccrediEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AccrediDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new AccrediDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Accredi.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);
        return builder.Build();
    }
}
