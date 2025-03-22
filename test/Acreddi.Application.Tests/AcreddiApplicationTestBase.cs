using Volo.Abp.Modularity;

namespace Acreddi;

public abstract class AcreddiApplicationTestBase<TStartupModule> : AcreddiTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
