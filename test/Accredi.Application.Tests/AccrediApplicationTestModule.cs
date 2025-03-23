using Volo.Abp.Modularity;

namespace Accredi;

[DependsOn(
    typeof(AccrediApplicationModule),
    typeof(AccrediDomainTestModule)
)]
public class AccrediApplicationTestModule : AbpModule
{

}
