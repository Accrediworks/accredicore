namespace Accredi.Crm.AccountLocations
{
    public static class AccountLocationConsts
    {
        private const string DefaultSorting = "{0}CreationTime desc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AccountLocation." : string.Empty);
        }

    }
}