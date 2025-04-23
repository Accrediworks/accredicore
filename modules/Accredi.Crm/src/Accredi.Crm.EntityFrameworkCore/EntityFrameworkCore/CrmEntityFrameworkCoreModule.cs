using Accredi.Crm.Contacts;
using Accredi.Crm.Accounts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Accredi.Crm.EntityFrameworkCore;

[DependsOn(
    typeof(CrmDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class CrmEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CrmDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */

        });
    }
}