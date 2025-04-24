namespace Accredi.Crm.ContactLevels
{
    public static class ContactLevelConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ContactLevel." : string.Empty);
        }

    }
}