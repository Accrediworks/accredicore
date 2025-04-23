using System;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.Contacts
{
    public class ContactAccount : Entity
    {

        public Guid ContactId { get; protected set; }

        public Guid AccountId { get; protected set; }

        private ContactAccount()
        {

        }

        public ContactAccount(Guid contactId, Guid accountId)
        {
            ContactId = contactId;
            AccountId = accountId;
        }

        public override object[] GetKeys()
        {
            return new object[]
                {
                    ContactId,
                    AccountId
                };
        }
    }
}