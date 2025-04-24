namespace Accredi.Crm.ContactStates
{
    public static class ContactStateConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ContactState." : string.Empty);
        }

    }
}