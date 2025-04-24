namespace Accredi.Crm.ContactEmails
{
    public static class ContactEmailConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ContactEmail." : string.Empty);
        }

    }
}