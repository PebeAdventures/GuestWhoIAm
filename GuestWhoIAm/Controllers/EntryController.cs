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

        public IActionResult Index()
        {
            return View();
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

            var id = _entryService.Save(entry);
            TempData["Id"] = id;
            return RedirectToAction("Add");

        }

        [HttpGet]
        public IActionResult GuessGame()
        {
            var list = _entryService.GetAllEntries();
            return View(list);
        }

        [HttpGet]
        public IActionResult EntryPostPartial()
        {
            return PartialView("_EntriesPost", _entryService.GetAllEntries());
        }

    }
}
