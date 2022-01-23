namespace JournalService.Models.DTO
{
    public class JournalEntryDto
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryBy { get; set; }
        public string Comment { get; set; }
    }
}
