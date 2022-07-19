using GuestWhoIAm.Models;
using GuestWhoIAm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace GuestWhoIAm.Controllers
{
    public class EntryController : Controller
    {
        private readonly IEntryService _entryService;

        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Entry entry)
        {

            if (!ModelState.IsValid)
            {
                return View(entry);
            }
            bool entryValidateCheck = new EntryValidator().Validate(entry);
            if (entryValidateCheck == false)
            {
                return View(entry);
            }
            else
            {
                _entryService.Save(entry);
                return RedirectToAction("Add");
            }




        }

        [HttpGet]
        public IActionResult GuessGame(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            var list = _entryService.GetAllEntries();
            var listToDisplay = new EntryToPageDTO(list).PreparePageToDisplay(pageSize, pageIndex);
            return View(listToDisplay);
        }

        [HttpPost]
        public IActionResult ChangePage(int? pageIndex)
        {
            var pageIndexToValidate = Request.Form["pageIndex"].First();
            int toValidateInt = Int32.Parse(pageIndexToValidate);

            bool checkCorrectPageNumber = new PageNumberValidator(_entryService).IsValid(toValidateInt);
            if (!checkCorrectPageNumber)
            {
                pageIndex = 1;
            }
            return RedirectToAction("GuessGame", "Entry", new { page = pageIndex });

        }

        [HttpPost]
        public IActionResult PageUp(string reportName)
        {
            int pageValue = 1;
            if (!reportName.Equals("/"))
            {
                string pageNumberAsString = reportName;
                string lastFragment = pageNumberAsString.Split('=').Last();
                pageValue = Int32.Parse(lastFragment);
            }

            return RedirectToAction("GuessGame", "Entry", new { page = pageValue + 1 });

        }
        [HttpPost]
        public IActionResult PageDown(string reportName)
        {
            int pageValue = 2;
            if (!reportName.Equals("/"))
            {
                string pageNumberAsString = reportName;
                string lastFragment = pageNumberAsString.Split('=').Last();
                pageValue = Int32.Parse(lastFragment);
            }
            if (pageValue == 1) { pageValue++; }
            return RedirectToAction("GuessGame", "Entry", new { page = pageValue - 1 });

        }

    }
}
