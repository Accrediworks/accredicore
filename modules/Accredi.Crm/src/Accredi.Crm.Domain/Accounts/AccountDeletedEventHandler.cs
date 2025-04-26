using Accredi.Crm.AccountLocations;

using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace Accredi.Crm.Accounts;

public class AccountDeletedEventHandler : ILocalEventHandler<EntityDeletedEventData<Account>>, ITransientDependency
{
    private readonly IAccountLocationRepository _accountLocationRepository;

    public AccountDeletedEventHandler(IAccountLocationRepository accountLocationRepository)
    {
        _accountLocationRepository = accountLocationRepository;

    }

    public async Task HandleEventAsync(EntityDeletedEventData<Account> eventData)
    {
        if (eventData.Entity is not ISoftDelete softDeletedEntity)
        {
            return;
        }

        if (!softDeletedEntity.IsDeleted)
        {
            return;
        }

        try
        {
            await _accountLocationRepository.DeleteManyAsync(await _accountLocationRepository.GetListByAccountIdAsync(eventData.Entity.Id));

        }
        catch
        {
            //...
        }
    }
}