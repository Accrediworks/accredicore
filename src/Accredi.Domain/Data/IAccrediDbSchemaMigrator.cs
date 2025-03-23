using System.Threading.Tasks;

namespace Accredi.Data;

public interface IAccrediDbSchemaMigrator
{
    Task MigrateAsync();
}
