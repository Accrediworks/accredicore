using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Accredi.Qualification;

[DependsOn(
    typeof(QualificationApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class QualificationHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(QualificationApplicationContractsModule).Assembly,
            QualificationRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<QualificationHttpApiClientModule>();
        });
    }
}
