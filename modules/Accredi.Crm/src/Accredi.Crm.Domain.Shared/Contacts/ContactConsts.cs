namespace Accredi.Crm.Contacts
{
    public static class ContactConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Contact." : string.Empty);
        }

    }
}