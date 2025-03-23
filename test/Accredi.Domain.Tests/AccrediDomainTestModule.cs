using Volo.Abp.Modularity;

namespace Accredi;

[DependsOn(
    typeof(AccrediDomainModule),
    typeof(AccrediTestBaseModule)
)]
public class AccrediDomainTestModule : AbpModule
{

}
