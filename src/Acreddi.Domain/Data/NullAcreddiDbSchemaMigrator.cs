using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Data;

/* This is used if database provider does't define
 * IAcreddiDbSchemaMigrator implementation.
 */
public class NullAcreddiDbSchemaMigrator : IAcreddiDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
