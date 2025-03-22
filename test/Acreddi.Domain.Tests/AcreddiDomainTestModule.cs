using Volo.Abp.Modularity;

namespace Acreddi;

[DependsOn(
    typeof(AcreddiDomainModule),
    typeof(AcreddiTestBaseModule)
)]
public class AcreddiDomainTestModule : AbpModule
{

}
