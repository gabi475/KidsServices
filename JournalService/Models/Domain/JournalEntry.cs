namespace JournalService.Models.Domain
{
    public class JournalEntry
    {
        public JournalEntry(DateTime entryDate, string entryBy, string comment)
        {
            EntryDate = entryDate;
            EntryBy = entryBy;
            Comment = comment;
        }

        public int Id { get; protected set; }
        public DateTime EntryDate { get; protected set; }
        public string EntryBy { get; protected set; }
        public string Comment { get; protected set; }
    }
}