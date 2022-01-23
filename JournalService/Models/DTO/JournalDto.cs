namespace JournalService.Models.DTO
{
    public class JournalDto
    {

        public string SocialSecurityNumber { get; set; }
        public IEnumerable<JournalEntryDto> Entries { get; set; }
    }
}