namespace Accredi.Crm.ContactTelephones
{
    public static class ContactTelephoneConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ContactTelephone." : string.Empty);
        }

    }
}