using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Accredi.Crm.ContactStates;

/* Creates initial data that is needed to property run the application
 * and make client-to-server communication possible.
 */
public class ContactStateDataSeedContributor(
    IContactStateRepository contactStateRepository,
    IGuidGenerator guidGenerator) : IDataSeedContributor, ITransientDependency
{
    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        var total = await contactStateRepository.GetCountAsync();

        if (total == 0)
        {
            await CreateStateAsync("Employed", ContactStateType.Active);
            await CreateStateAsync("Retired", ContactStateType.Inactive);
        }
    }

    private async Task CreateStateAsync(string name, ContactStateType type)
    {
        var id = guidGenerator.Create();
        var entity = new ContactState(id, name, type);
        await contactStateRepository.InsertAsync(entity);
    }
}