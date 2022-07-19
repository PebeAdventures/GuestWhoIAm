using GuestWhoIAm.Services.Interfaces;

namespace GuestWhoIAm.Models
{
    public class PageNumberValidator
    {
        private readonly IEntryService _entryService;

        public PageNumberValidator(IEntryService entryService)
        {
            _entryService = entryService;
        }

        public bool IsValid(int numberToValidate)
        {
            int maxPagesNumber = GetMaxPageNumbers();
            if (numberToValidate > maxPagesNumber) { return false; } else { return true; }
        }

        private int GetMaxPageNumbers()
        {
            var list = _entryService.GetAllEntries();
            var numberofEntries = list.Count();
            double numberOfEntriesAsDouble = (double)numberofEntries;
            var maxNumberOfPagesInDouble = (numberOfEntriesAsDouble / 5);
            int maxNumberOfPages = Convert.ToInt32(Math.Ceiling(maxNumberOfPagesInDouble));
            return maxNumberOfPages;
        }
    }
}
