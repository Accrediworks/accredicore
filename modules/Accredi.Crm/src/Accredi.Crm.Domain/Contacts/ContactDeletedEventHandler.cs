using Accredi.Crm.ContactEmails;
using Accredi.Crm.ContactTelephones;

using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace Accredi.Crm.Contacts;

public class ContactDeletedEventHandler : ILocalEventHandler<EntityDeletedEventData<Contact>>, ITransientDependency
{
    private readonly IContactEmailRepository _contactEmailRepository;
    private readonly IContactTelephoneRepository _contactTelephoneRepository;

    public ContactDeletedEventHandler(IContactEmailRepository contactEmailRepository, IContactTelephoneRepository contactTelephoneRepository)
    {
        _contactEmailRepository = contactEmailRepository;
        _contactTelephoneRepository = contactTelephoneRepository;

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
            await _contactEmailRepository.DeleteManyAsync(await _contactEmailRepository.GetListByContactIdAsync(eventData.Entity.Id));
            await _contactTelephoneRepository.DeleteManyAsync(await _contactTelephoneRepository.GetListByContactIdAsync(eventData.Entity.Id));

        }
        catch
        {
            //...
        }
    }
}