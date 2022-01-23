using JournalService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JournalService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        public DbSet<Journal> Journal { get; set; }
    }
}

