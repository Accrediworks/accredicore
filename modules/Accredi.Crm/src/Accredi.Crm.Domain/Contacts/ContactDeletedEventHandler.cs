using Accredi.Crm.ContactTelephones;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.ContactAccounts;

using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace Accredi.Crm.Contacts;

public class ContactDeletedEventHandler : ILocalEventHandler<EntityDeletedEventData<Contact>>, ITransientDependency
{
    private readonly IContactTelephoneRepository _contactTelephoneRepository;
    private readonly IContactEmailRepository _contactEmailRepository;
    private readonly IContactAccountRepository _contactAccountRepository;

    public ContactDeletedEventHandler(IContactTelephoneRepository contactTelephoneRepository, IContactEmailRepository contactEmailRepository, IContactAccountRepository contactAccountRepository)
    {
        _contactTelephoneRepository = contactTelephoneRepository;
        _contactEmailRepository = contactEmailRepository;
        _contactAccountRepository = contactAccountRepository;

    }

    public async Task HandleEventAsync(EntityDeletedEventData<Contact> eventData)
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
            await _contactTelephoneRepository.DeleteManyAsync(await _contactTelephoneRepository.GetListByContactIdAsync(eventData.Entity.Id));
            await _contactEmailRepository.DeleteManyAsync(await _contactEmailRepository.GetListByContactIdAsync(eventData.Entity.Id));
            await _contactAccountRepository.DeleteManyAsync(await _contactAccountRepository.GetListByContactIdAsync(eventData.Entity.Id));

        }
        catch
        {
            //...
        }
    }
}