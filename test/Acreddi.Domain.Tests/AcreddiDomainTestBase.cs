using Volo.Abp.Modularity;

namespace Acreddi;

/* Inherit from this class for your domain layer tests. */
public abstract class AcreddiDomainTestBase<TStartupModule> : AcreddiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
