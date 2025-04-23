using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Accredi.Crm;

[DependsOn(
    typeof(CrmDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationAbstractionsModule)
    )]
public class CrmApplicationContractsModule : AbpModule
{

}
