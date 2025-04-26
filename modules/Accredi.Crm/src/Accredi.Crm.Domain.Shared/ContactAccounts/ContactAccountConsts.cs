namespace Accredi.Crm.ContactAccounts
{
    public static class ContactAccountConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ContactAccount." : string.Empty);
        }

    }
}