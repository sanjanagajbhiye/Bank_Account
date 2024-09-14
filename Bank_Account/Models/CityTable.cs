using System;
using System.Collections.Generic;

namespace Bank_Account.Models
{
    public partial class CityTable
    {
        public CityTable()
        {
            AccountOpeningFormTables = new HashSet<AccountOpeningFormTable>();
            BranchTables = new HashSet<BranchTable>();
        }

        public int CityCode { get; set; }
        public string? CityName { get; set; }
        public int? CityStateCode { get; set; }

        public virtual StateTable? CityStateCodeNavigation { get; set; }
        public virtual ICollection<AccountOpeningFormTable> AccountOpeningFormTables { get; set; }
        public virtual ICollection<BranchTable> BranchTables { get; set; }
    }
}
