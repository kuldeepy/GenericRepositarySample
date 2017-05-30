namespace BusinessEntities.User
{
    public abstract class Settings
    {
        public string Type { get; set; }

        public string Rights { get; set; }

        public bool IsDeleted { get; set; }

        public string StartPage { get; set; }

        public string DateFormat { get; set; }

        public string RecordsPerPageClRL { get; set; }

        public string RecordsPerPageCuRL { get; set; }

        public int RecordSetsClaimSection { get; set; }

        public int RecordsSetsClaimSection { get; set; }

        public int RecordsSearchClaimSection { get; set; }

        public int RecordsSearchCustomerSection { get; set; }

        public string LoginName { get; set; }

        public string IPAddress { get; set; }

        public bool AllowAllocationAccess { get; set; }

        public int FailedLoginAttempts { get; set; }

        public bool AllowClaimImportDelete { get; set; }

        public bool AllowCustomerDelete { get; set; }
    }
}
