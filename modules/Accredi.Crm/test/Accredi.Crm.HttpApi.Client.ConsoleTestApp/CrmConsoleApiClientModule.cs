using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Accredi.Crm;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CrmHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CrmConsoleApiClientModule : AbpModule
{

}
