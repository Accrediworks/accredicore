using Volo.Abp.Modularity;

namespace Acreddi;

[DependsOn(
    typeof(AcreddiApplicationModule),
    typeof(AcreddiDomainTestModule)
)]
public class AcreddiApplicationTestModule : AbpModule
{

}
