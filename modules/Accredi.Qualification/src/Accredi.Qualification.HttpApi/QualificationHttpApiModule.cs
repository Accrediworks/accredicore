using Localization.Resources.AbpUi;
using Accredi.Qualification.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Accredi.Qualification;

[DependsOn(
    typeof(QualificationApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class QualificationHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(QualificationHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<QualificationResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
