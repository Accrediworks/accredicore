using Volo.Abp.Modularity;

namespace Accredi;

public abstract class AccrediApplicationTestBase<TStartupModule> : AccrediTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
