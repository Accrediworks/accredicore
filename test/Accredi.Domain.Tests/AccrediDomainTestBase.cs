using Volo.Abp.Modularity;

namespace Accredi;

/* Inherit from this class for your domain layer tests. */
public abstract class AccrediDomainTestBase<TStartupModule> : AccrediTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
