using System;
using System.Collections.Generic;

namespace Bank_Account.Models
{
    public partial class StateTable
    {
        public StateTable()
        {
            AccountOpeningFormTables = new HashSet<AccountOpeningFormTable>();
            CityTables = new HashSet<CityTable>();
        }

        public int StateCode { get; set; }
        public string StateName { get; set; } = null!;

        public virtual ICollection<AccountOpeningFormTable> AccountOpeningFormTables { get; set; }
        public virtual ICollection<CityTable> CityTables { get; set; }
    }
}
