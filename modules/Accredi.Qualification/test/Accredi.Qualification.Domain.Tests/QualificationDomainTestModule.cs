using Volo.Abp.Modularity;

namespace Accredi.Qualification;

[DependsOn(
    typeof(QualificationDomainModule),
    typeof(QualificationTestBaseModule)
)]
public class QualificationDomainTestModule : AbpModule
{

}
