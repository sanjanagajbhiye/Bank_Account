using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank_Account.Models
{
    public partial class AccountOpeningFormTable
    {
        public int FormNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FormFillingDate { get; set; }
        public TimeSpan? FormFillingTime { get; set; }

        [Required(ErrorMessage = "Please Select Title")]
        public int? CustTitle { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        public string? CustFirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Middle Name")]
        public string? CustMiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string? CustLastName { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public int CustSex { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? CustDateOfBirth { get; set; }
        public int? CustAge { get; set; }
        [Required(ErrorMessage = "Please Enter STD Code")]
        [RegularExpression(@"^\d{1,5}$", ErrorMessage = "Entered STD is not valid.")]
        public string? CustStdCode { get; set; }
        [Required]
        [RegularExpression(@"^\d{5,10}$", ErrorMessage = "Entered Telephone is not valid.")]
        public string? CustTelephone { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
           ErrorMessage = "Entered Mobile Number is not valid.")]
        public string? CustMobile { get; set; }

        [Required(ErrorMessage = "Please Enter E-mail")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? CustEmailId { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        public int? CustStateCode { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        public int? CustCityCode { get; set; }

        [Required(ErrorMessage = "Please Select Branch")]
        public int? CustBranchCode { get; set; }

        [Required(ErrorMessage = "Please select Account Type")]
        public int? CustAccountType { get; set; }


        [Required(ErrorMessage = "Please select PreferredLanguage")]
        public int? CustPreferredLanguage { get; set; }

        public virtual BranchTable? CustBranchCodeNavigation { get; set; }
        public virtual CityTable? CustCityCodeNavigation { get; set; }
        public virtual LanguageTable1? CustPreferredLanguageNavigation { get; set; }
        public virtual StateTable? CustStateCodeNavigation { get; set; }

        public string FormFillingTimeString
        {
            get
            {
                return FormFillingTime?.ToString("hh\\:mm") ?? "Not specified";
            }
        }
    }
}
