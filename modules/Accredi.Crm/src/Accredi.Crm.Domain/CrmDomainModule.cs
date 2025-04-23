using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Accredi.Crm;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(CrmDomainSharedModule)
)]
public class CrmDomainModule : AbpModule
{

}
