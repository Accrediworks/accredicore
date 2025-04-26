using Volo.Abp.Modularity;

namespace Accredi.Qualification;

[DependsOn(
    typeof(QualificationApplicationModule),
    typeof(QualificationDomainTestModule)
    )]
public class QualificationApplicationTestModule : AbpModule
{

}
