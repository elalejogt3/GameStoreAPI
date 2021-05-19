using GameStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customers = new List<Customer>()
            {
                new Customer(){Id = 1, Name = "Jimmy Kimmel", Email = "jkimme@example.com" },
                new Customer(){Id = 2, Name = "Jimmy Fallon" },
                new Customer(){Id = 3, Name = "Conan Obrien" },
                new Customer(){Id = 4, Name = "Seth McClaren" }
            };

            modelBuilder.Entity<Customer>().HasData(customers);

            base.OnModelCreating(modelBuilder);
        }

    }
}
