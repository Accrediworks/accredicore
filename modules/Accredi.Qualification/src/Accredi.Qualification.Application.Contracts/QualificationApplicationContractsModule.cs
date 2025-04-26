using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Accredi.Qualification;

[DependsOn(
    typeof(QualificationDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationAbstractionsModule)
    )]
public class QualificationApplicationContractsModule : AbpModule
{

}
