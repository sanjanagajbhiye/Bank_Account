using System;
using System.Collections.Generic;

namespace Bank_Account.Models
{
    public partial class LanguageTable1
    {
        public LanguageTable1()
        {
            AccountOpeningFormTables = new HashSet<AccountOpeningFormTable>();
        }

        public int LanguageCode { get; set; }
        public string? LanguageName { get; set; }

        public virtual ICollection<AccountOpeningFormTable> AccountOpeningFormTables { get; set; }
    }
}
