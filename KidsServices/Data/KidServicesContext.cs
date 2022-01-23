using System;
using KidsServices.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidsServices.Models
{
    public class KidServicesContext: DbContext
    {
     


       public KidServicesContext(DbContextOptions<KidServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kid> Kids { get; set; }

      
    }
}

