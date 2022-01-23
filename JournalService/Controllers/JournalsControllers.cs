using JournalService.Data;
using JournalService.Models.Domain;
using JournalService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JournalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalsController : ControllerBase
    {
        private ApplicationContext Context { get; }

        public JournalsController(ApplicationContext context)
        {
            Context = context;
        }

        // POST /api/journals/19900101-2010/entries
        [HttpPost("{socialSecurityNumber}/entries")]
        public IActionResult MakeJournalEntry(string socialSecurityNumber, NewJournalEntryDto newJournalEntryDto)
        {
            var journal = Context.Journal.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (journal == null)
            {
                journal = new Journal(socialSecurityNumber);

                Context.Journal.Add(journal);
            }

            var journalEntry = new JournalEntry(
               entryBy: newJournalEntryDto.EntryBy,
               entryDate: newJournalEntryDto.EntryDate,
               comment: newJournalEntryDto.Comment
            );

            journal.Entries.Add(journalEntry);

            Context.SaveChanges();

            var journalEntryDto = new JournalEntryDto
            {
                Id = journalEntry.Id,
                EntryBy = journalEntry.EntryBy,
                EntryDate = journalEntry.EntryDate,
                Comment = journalEntry.Comment
            };

            return Created("", journalEntryDto); // 201 Created
        }

        // GET /api/journals/19900101-2010
        [HttpGet("{socialSecurityNumber}")]
        public ActionResult<JournalDto> GetJournal(string socialSecurityNumber)
        {
            var journal = Context.Journal
                .Include(x => x.Entries)
                .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (journal == null)
                return NotFound(); // 404 Not Found

            var journalDto = new JournalDto
            {
                SocialSecurityNumber = journal.SocialSecurityNumber,
                Entries = journal.Entries.Select(x => new JournalEntryDto
                {
                    Id = x.Id,
                    EntryBy = x.EntryBy,
                    EntryDate = x.EntryDate,
                    Comment = x.Comment
                })
            };

            return journalDto;
        }
    }
}
