using System.Threading.Tasks;

namespace Acreddi.Data;

public interface IAcreddiDbSchemaMigrator
{
    Task MigrateAsync();
}
