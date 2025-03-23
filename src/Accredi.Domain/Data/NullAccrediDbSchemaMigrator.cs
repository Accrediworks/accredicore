using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Accredi.Data;

/* This is used if database provider does't define
 * IAccrediDbSchemaMigrator implementation.
 */
public class NullAccrediDbSchemaMigrator : IAccrediDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
