using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Accredi.Qualification;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QualificationHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class QualificationConsoleApiClientModule : AbpModule
{

}
