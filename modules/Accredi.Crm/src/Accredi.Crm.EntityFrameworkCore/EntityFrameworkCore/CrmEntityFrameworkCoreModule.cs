using Accredi.Crm.ContactLevels;
using Accredi.Crm.ContactStates;
using Accredi.Crm.ContactTelephones;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.Countries;
using Accredi.Crm.AccountLocations;
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

            options.AddRepository<Account, Accounts.EfCoreAccountRepository>();

            options.AddRepository<AccountLocation, AccountLocations.EfCoreAccountLocationRepository>();

            options.AddRepository<Country, Countries.EfCoreCountryRepository>();

            options.AddRepository<Contact, Contacts.EfCoreContactRepository>();

            options.AddRepository<ContactEmail, ContactEmails.EfCoreContactEmailRepository>();

            options.AddRepository<ContactTelephone, ContactTelephones.EfCoreContactTelephoneRepository>();

            options.AddRepository<ContactState, ContactStates.EfCoreContactStateRepository>();

            options.AddRepository<ContactLevel, ContactLevels.EfCoreContactLevelRepository>();

        });
    }
}