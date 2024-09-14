using System;
using System.Collections.Generic;

namespace Bank_Account.Models
{
    public partial class BranchTable
    {
        public BranchTable()
        {
            AccountOpeningFormTables = new HashSet<AccountOpeningFormTable>();
        }

        public int BranchCode { get; set; }
        public string? BranchName { get; set; }
        public int? BranchCityCode { get; set; }

        public virtual CityTable? BranchCityCodeNavigation { get; set; }
        public virtual ICollection<AccountOpeningFormTable> AccountOpeningFormTables { get; set; }
    }
}
