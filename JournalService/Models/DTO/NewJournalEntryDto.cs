namespace JournalService.Models.DTO
{
    public class NewJournalEntryDto
    {
        public DateTime EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Comment { get; set; }
    }
}
