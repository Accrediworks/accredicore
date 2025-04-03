using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Accredi.Data;
using Volo.Abp.DependencyInjection;

namespace Accredi.EntityFrameworkCore;

public class EntityFrameworkCoreAccrediDbSchemaMigrator
    : IAccrediDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAccrediDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AccrediDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AccrediDbContext>()
            .Database
            .MigrateAsync();
    }
} 
 