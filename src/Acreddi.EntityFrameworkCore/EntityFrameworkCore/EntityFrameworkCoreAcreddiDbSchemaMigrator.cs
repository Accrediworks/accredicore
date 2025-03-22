using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acreddi.Data;
using Volo.Abp.DependencyInjection;

namespace Acreddi.EntityFrameworkCore;

public class EntityFrameworkCoreAcreddiDbSchemaMigrator
    : IAcreddiDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAcreddiDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AcreddiDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AcreddiDbContext>()
            .Database
            .MigrateAsync();
    }
}
