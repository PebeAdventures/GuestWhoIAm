namespace GuestWhoIAm.Models
{
    public class EntryToPageDTO
    {
        private readonly IEnumerable<Entry> entries;
        public EntryToPageDTO(IEnumerable<Entry> entries)
        {
            this.entries = entries;
        }





        public IEnumerable<Entry> PreparePageToDisplay(int entriesNumber, int pageIndex)
        {
            return PrepareListToDisplay(entriesNumber, pageIndex);
        }

        private IEnumerable<Entry> PrepareListToDisplay(int entriesNumber, int pageIndex)
        {
            List<Entry> entriesList = entries.ToList();
            var entriesCount = entriesList.Count;
            var entriesStartPoint = entriesNumber * (pageIndex - 1);
            var entriesEndPoint = entriesNumber * (pageIndex) - 1;
            var entriesListToDisplay = new List<Entry>();
            if (entriesCount <= entriesEndPoint) entriesEndPoint = entriesCount - 1;


            for (int i = entriesStartPoint; i <= entriesEndPoint; i++)
            {
                entriesListToDisplay.Add(entriesList[i]);
            }

            return entriesListToDisplay;
        }
    }
}
