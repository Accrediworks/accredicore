using Volo.Abp.Modularity;

namespace Accredi.Crm;

[DependsOn(
    typeof(CrmDomainModule),
    typeof(CrmTestBaseModule)
)]
public class CrmDomainTestModule : AbpModule
{

}
