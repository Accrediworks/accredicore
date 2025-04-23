using Volo.Abp.Modularity;

namespace Accredi.Crm;

[DependsOn(
    typeof(CrmApplicationModule),
    typeof(CrmDomainTestModule)
    )]
public class CrmApplicationTestModule : AbpModule
{

}
