using GuestWhoIAm.Models;
using GuestWhoIAm.Services.Interfaces;

namespace GuestWhoIAm.Services
{
    public class EntryService : IEntryService
    {

        private readonly DbGuestContext _guestContext;
        public EntryService(DbGuestContext guestContext)
        {
            _guestContext = guestContext;
        }

        public IEnumerable<Entry> GetAllEntries()
        {
            var entries = _guestContext.Entries.ToList();
            entries.Reverse();
            return entries;
        }

        public int Save(Entry entry)
        {
            entry.DateTime = DateTime.Now;
            _guestContext.Entries.Add(entry);
            _guestContext.SaveChanges();

            return entry.Id;
        }
    }
}
