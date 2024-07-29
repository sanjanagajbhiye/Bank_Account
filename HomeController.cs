using Bank_Account.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;

namespace Bank_Account.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Account_databaseContext dbcontext;

        public HomeController(ILogger<HomeController> logger, Account_databaseContext dbcontext)
        {
            _logger = logger;
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            // Retrieve the data to display in the Index view
            var data = dbcontext.AccountOpeningFormTables.ToList();
            
            var branch = dbcontext.BranchTables.ToList();
            DateTime currentDate = DateTime.Now;

            ViewBag.CurrentDate = currentDate.ToString("dd/MM/yyyy");
            // Prepare the gender dictionary
            var genderDict = new Dictionary<string, string>
            {
                { "1", "Male" },
                { "2", "Female" },
                { "3", "Other" }
            };

            // Prepare the title dictionary
            var titleDict = new Dictionary<string, string>
            {
                { "1", "Mr" },
                { "2", "Ms" },
                { "3", "Mrs" },
                { "4", "Mst" },
                { "5", "Baby" }
            };

            var accDict = new Dictionary<string, string>
            {
                {"1" ,"Savings"},
                { "2" ,"Current"},
                { "3" ,"Recurring Deposits" },
                {"4","Term Loan" }
            };
            var branchDict = new Dictionary<string, string>(); 
                
            foreach(var item in branch)
            {
                branchDict[item.BranchCode.ToString()] = item.BranchName;
            }
        

        // Pass the dictionaries to the view via ViewBag
        ViewBag.GenderDict = genderDict;
            ViewBag.TitleDict = titleDict;
            ViewBag.AccDict = accDict;
            ViewBag.BranchDict = branchDict;

            // Pass the data to the view
            return View(data);
        }

        public IActionResult Create()
        {
            var data = dbcontext.AccountOpeningFormTables.ToList();
            ViewBag.FormNumber = data.Count + 1;
            ViewBag.currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            ViewBag.currentTime = DateTime.Now.ToString("hh:mm:ss");
            // Populate the dropdown list
            ViewBag.TitleList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Mr", Value = "1" },
                new SelectListItem { Text = "Ms", Value = "2" },
                new SelectListItem { Text = "Mrs", Value = "3" },
                new SelectListItem { Text = "Mst", Value = "4" },
                new SelectListItem { Text = "Baby", Value = "5" }
            };

            ViewBag.GenderList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Male", Value = "1" },
                new SelectListItem { Text = "Female", Value = "2" },
                new SelectListItem { Text = "Other", Value = "3" }
            };

            // Bind States in the ddl
            var states = dbcontext.StateTables.ToList();

            var stateList = states.Select(state => new SelectListItem
            {
                Value = state.StateCode.ToString(),
                Text = state.StateName
            }).ToList();

            ViewBag.StateList = stateList;

            //Bind Account Type
            ViewBag.AccountTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Savings", Value = "1" },
                new SelectListItem { Text = "Current", Value = "2" },
                new SelectListItem { Text = "Recurring Deposits", Value = "3" },
                new SelectListItem { Text = "Term Loan", Value = "4" }
            };

            //Bind Languages
            var Languages = dbcontext.LanguageTable1s.ToList();

            var LanguageList = Languages.Select(Languages => new SelectListItem
            {
                Value = Languages.LanguageCode.ToString(),
                Text = Languages.LanguageName
            }).ToList();

            ViewBag.LanguageList = LanguageList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountOpeningFormTable model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.FormFillingDate = DateTime.Today;  // Set current date
                    model.FormFillingTime = DateTime.Now.TimeOfDay;  // Set current time
                    // Add the model to DbContext
                    dbcontext.AccountOpeningFormTables.Add(model);
                    dbcontext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetCitybyStateId(int stateId)
        {
            var cities = dbcontext.CityTables
                .Where(c => c.CityStateCode == stateId)
                .Select(c => new SelectListItem
                {
                    Value = c.CityCode.ToString(),
                    Text = c.CityName
                }).ToList();

            return Json(cities);
        }

        public JsonResult GetBranchbyCityId(int cityId)
        {
            var branches = dbcontext.BranchTables
                .Where(b => b.BranchCityCode == cityId)
                .Select(b => new SelectListItem
                {
                    Value = b.BranchCode.ToString(),
                    Text = b.BranchName
                }).ToList();

            return Json(branches);
        }

        [HttpGet]
        public ActionResult GetAgeByDateOfBirth(DateTime dob)
        {
            int age = CalculateAge(dob);
            return Json(new { age = age });
        }

        private int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age))
                age--;
            return age < 0 ? 0 : age;
        }

        public JsonResult GetGenderByTitle(int titleId)
        {
            // Mapping of title to gender
            var titleToGenderMap = new Dictionary<int, int>
            {
                { 1, 1 }, // Mr -> Male
                { 2, 2 }, // Ms -> Female
                { 3, 2 }, // Mrs -> Female
                { 4, 1 }, // Mst -> Male
                { 5, 2 }  // Baby -> Female
            };

            // Default to an empty value if titleId is not in the map
            int genderId = titleToGenderMap.ContainsKey(titleId) ? titleToGenderMap[titleId] : 0;

            return Json(new { GenderId = genderId });
        }

        

    }
}