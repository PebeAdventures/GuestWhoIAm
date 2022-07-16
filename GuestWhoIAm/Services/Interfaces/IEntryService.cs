using GuestWhoIAm.Models;

namespace GuestWhoIAm.Services.Interfaces
{
    public interface IEntryService
    {
        int Save(Entry entry);
        IEnumerable<Entry> GetAllEntries();
    }
}
