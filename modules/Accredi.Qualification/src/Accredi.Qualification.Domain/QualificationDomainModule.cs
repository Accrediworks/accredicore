using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Accredi.Qualification;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(QualificationDomainSharedModule)
)]
public class QualificationDomainModule : AbpModule
{

}
