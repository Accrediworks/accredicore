using System.Threading.Tasks;
using Accredi.Crm.ContactStates;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Accredi.Crm.ContactLevels;

/* Creates initial data that is needed to property run the application
 * and make client-to-server communication possible.
 */
public class ContactLevelDataSeedContributor(
    IContactLevelRepository contactLevelRepository,
    IGuidGenerator guidGenerator) : IDataSeedContributor, ITransientDependency
{
    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        var total = await contactLevelRepository.GetCountAsync();

        if (total == 0)
        {
            await CreateLevelAsync("Owner", ContactLevelType.Owner);
            await CreateLevelAsync("Manager", ContactLevelType.Manager);
            await CreateLevelAsync("Supervisor", ContactLevelType.Manager);
            await CreateLevelAsync("Employee", ContactLevelType.Employee);
        }
    }

    private async Task CreateLevelAsync(string name, ContactLevelType type)
    {
        var id = guidGenerator.Create();
        var entity = new ContactLevel(id, name, type);
        await contactLevelRepository.InsertAsync(entity);
    }
}