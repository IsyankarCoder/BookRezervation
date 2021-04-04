using BookRezervation.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRezervation.Data
{
    public class BookRezervationContext
        :DbContext
    {

         public virtual DbSet<Country> Country { get; set; }
         public virtual DbSet<Penalty> Penalty { get; set; }

        public BookRezervationContext(DbContextOptions<BookRezervationContext> contextOptions)
           : base(contextOptions)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Country>().HasMany(c => c.Penalties).WithOne(d => d.Country).IsRequired();

            modelBuilder.Entity<Penalty>().Property(d => d.Amout).HasPrecision(6, 2);
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Penalty>().ToTable("Penalty"); 

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

    }
}
