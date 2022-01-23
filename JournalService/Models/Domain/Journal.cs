namespace JournalService.Models.Domain
{
    public class Journal
    {
        public Journal(string socialSecurityNumber)
        {
            SocialSecurityNumber = socialSecurityNumber;
        }

        public int Id { get; protected set; }
        public string SocialSecurityNumber { get; protected set; }
        public ICollection<JournalEntry> Entries { get; protected set; } = new List<JournalEntry>();
    }
}